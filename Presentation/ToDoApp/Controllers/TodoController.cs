using ToDoApp.Data.Entities;
using ToDoApp.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ToDoContext toDoContext;

        public TodoController(ToDoContext toDoContext)
        {
            this.toDoContext = toDoContext;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var allToDo = await toDoContext.Set<ToDo>().ToListAsync(cancellationToken);
       
            return View(allToDo);
        }


        #region Create

        [HttpGet]
        public async Task<IActionResult> CreateTodo(CancellationToken cancellationToken)
        {
            return View();
        }
       

        [HttpPost]
        public async Task<IActionResult> CreateTodo(ToDo createTodo,CancellationToken cancellationToken)
        {
            createTodo.CreatedDate = DateTime.UtcNow;
            await toDoContext.AddAsync(createTodo,cancellationToken);
            await toDoContext.SaveChangesAsync(cancellationToken);
            return View();
        }

        #endregion

        #region Delete

        [HttpGet]
        public async Task<IActionResult> DeleteTodo(CancellationToken cancellationToken,int id)
        {
            var todo = toDoContext.Set<ToDo>().Find(id);
            return View(todo);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTodo(int id,CancellationToken cancellationToken)
        {
            var deleteToDo = await toDoContext.Set<ToDo>().FindAsync(id);

            if (deleteToDo is not null)
            {
                toDoContext.Remove(deleteToDo);
                await toDoContext.SaveChangesAsync(cancellationToken);
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region UpdateToDo

        [HttpGet]
        public async Task<IActionResult> UpdateTodo(int id, CancellationToken cancellationToken)
        {
            var todo = await toDoContext.Set<ToDo>().FindAsync(id,cancellationToken);
            return View(todo);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTodo(ToDo update , CancellationToken cancellationToken)
        {
            update.ModifiedDate = DateTime.UtcNow;

            var originalToDo = await toDoContext.Set<ToDo>().FindAsync(update.Id);

            toDoContext.Set<ToDo>().Entry(originalToDo).CurrentValues.SetValues(update);
            await toDoContext.SaveChangesAsync(cancellationToken);

            return View();
        }

        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int id, CancellationToken cancellationToken)
        {
            var toDo = await toDoContext.Set<ToDo>().FindAsync(id);

            return View(toDo);
        }

        #endregion

    }
}
