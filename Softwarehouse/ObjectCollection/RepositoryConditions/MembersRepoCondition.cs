﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCollection.RepositoryConditions
{
    public class MembersRepoCondition
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string SaltString { get; set; }
    }
}
