﻿using Suls.Data;
using Suls.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Suls.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext db;

        public ProblemsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, ushort points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points,
            };

            this.db.Problems.Add(problem);
            db.SaveChanges();
        }

        public IEnumerable<HomePageProblemViewModel> GetAll()
        {
            var problems = this.db.Problems.Select(x => new HomePageProblemViewModel 
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count(),
            }).ToList();

            return problems;
        }

        public string GetnameById(string id)
        {
            var problemName = this.db.Problems
                .Where(x => x.Id == id)
                .Select(x => x.Name)
                .FirstOrDefault();

            return problemName;
        }

        public ProblemViewModel GetById(string id)
        {
            return this.db.Problems.Where(x => x.Id == id)
                .Select(x =>  new ProblemViewModel
                {
                    Name = x.Name,
                    Submissions = x.Submissions.Select(s => new SubmissionViewModel
                    {
                        CreatedOn = s.CreatedOn,
                        SubmissionId = s.Id,
                        AchievedResult = s.AchievedResults,
                        Username = s.User.Username,
                        MaxPoints = x.Points,
                    })
                }).FirstOrDefault();
        }
    }
}
