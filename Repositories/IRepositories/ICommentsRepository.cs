﻿using Models.DTOs.ForCreationDTO;
using Models.DTOs.ForUpdateDTO;
using Models.Models;
using Models.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface ICommentsRepository :  IBaseRepository<Comments, CommentsParams, CommentsForCreationDTO, 
        CommentsForUpdateDTO, Guid>
    {
    }
}
