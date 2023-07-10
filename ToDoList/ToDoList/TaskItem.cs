using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList;

public class TaskItem
{
    public string Id { get; set; }
    public string TaskName { get; set; }
    public bool IsDone { get; set; }
}
