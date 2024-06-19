using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApi.Data;
using UniversityApp.Core.Entites;
using UniversityApp.Data.Repositories.Interfaces;

namespace UniversityApp.Data.Repositories.Implmentations
{
    public class GroupRepository :Repository<Group> ,IGroupRepository
    {
        public GroupRepository(UniversityDbContext context):base(context) 
        {
            
        }
    }
}
