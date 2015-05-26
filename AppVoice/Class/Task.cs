using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    public class Task
    {
       
        string title, description, imagePath,  comment;
        int taskId, exerciseId;

        public Task(string title, string description, string imagePath,  string comment, int exerciseId)
        {
            this.title = title;
            this.description = description;
            this.imagePath = imagePath;
            this.comment = comment;
            this.exerciseId = exerciseId;
        }

        public Task(int taskId, string title, string description, string imagePath, string comment, int exerciseId) : this(title, description, imagePath, comment, exerciseId)
        {
            this.taskId = taskId;
        }

        public int TaskId
        {
            set
            {
                taskId = value;
            }
            get
            {
                return taskId;
            }
        }
        public string Title
        {
            set
            {
                title = value;
            }
            get
            {
                return title;
            }
        }
        public string Description
        {
            set
            {
                description = value;
            }
            get
            {
                return description;
            }
        }
        public string ImagePath
        {
            set
            {
                imagePath = value;
            }
            get
            {
                return imagePath;
            }
        }
        public string Comment
        {
            set
            {
                comment = value;
            }
            get
            {
                return comment;
            }
        }
        public int ExerciseId
        {
            set
            {
                exerciseId = value;
            }
            get
            {
                return exerciseId;
            }
        }

    }
}