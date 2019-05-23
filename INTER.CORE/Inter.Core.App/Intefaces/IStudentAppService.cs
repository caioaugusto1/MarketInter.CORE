using Inter.Core.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inter.Core.App.Intefaces
{
    public interface IStudentAppService
    {
        StudentViewModel Add(StudentViewModel studentViewModel);
    }
}
