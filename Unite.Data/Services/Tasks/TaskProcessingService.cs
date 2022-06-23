﻿using System;
using System.Linq;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Services.Tasks
{
    public class TasksProcessingService
    {
        private readonly DomainDbContext _dbContext;


        public TasksProcessingService(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Process(TaskType type, TaskTargetType targetType, int bucketSize, Action<Unite.Data.Entities.Tasks.Task[]> handler)
        {
            while (true)
            {
                var tasks = _dbContext.Tasks
                    .Where(task => task.TypeId == type && task.TargetTypeId == targetType)
                    .OrderByDescending(task => task.Date)
                    .Take(bucketSize)
                    .ToArray();

                if (tasks != null && tasks.Any())
                {
                    handler.Invoke(tasks);

                    _dbContext.Tasks.RemoveRange(tasks);
                    _dbContext.SaveChanges();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
