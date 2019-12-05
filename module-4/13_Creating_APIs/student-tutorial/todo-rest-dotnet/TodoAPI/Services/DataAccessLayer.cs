using System;
using System.Collections.Generic;
using TodoAPI.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Services
{
    public class DataAccessLayer : IDataAccessLayer<Todo>
    {
        public List<Todo> todos { get; set; }

        public DataAccessLayer()
        {
            this.todos = new List<Todo> {
                new Todo {id=1,task="Wake up",completed=false},
                new Todo {id=2,task="Morning Movement",completed=false},
                new Todo {id=3,task="Coffee",completed=false},
                new Todo {id=4,task="Journal",completed=false},
                new Todo {id=5,task="Shower & Get Dressed",completed=false},
                new Todo {id=6,task="Drive to work",completed=false},
                new Todo {id=7,task="Give Presentation",completed=false},
                new Todo {id=8,task="Drive Home",completed=false},
                new Todo {id=9,task="Eat Dinner",completed=false},
                new Todo {id=10,task="Go to Sleep",completed=false}
            };
        }

        public List<Todo> GetAll()
        {
            return this.todos;
        }

        public Todo Get(int id)
        {
            return todos.Find(todo => todo.id == id);
        }

        public void Add(Todo todo)
        {
            todos.Add(todo);
            Console.Write(todos.Count);
        }

        public void Update(Todo todo)
        {
            todos[todos.FindIndex(t => t.id == todo.id)] = todo;
        }

        public void Delete(int id) 
        {
            todos.Remove(todos.Find(t => t.id == id));
        }

    }

}