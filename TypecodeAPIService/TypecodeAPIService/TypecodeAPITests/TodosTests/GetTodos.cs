using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using TypecodeAPIService.APIRunners;
using TypecodeAPIService.DTOs;

namespace TypecodeAPIService.TypecodeAPITests.TodosTests
{
    public class GetTodos
    {
        TypecodeAPIServices<TodosDTO[]> AllTodosService;

        [Test]
        public void GetAllTodos_StatusIs_OK()
        {
            AllTodosService = new TypecodeAPIServices<TodosDTO[]>(new UsersAPIRunner(new RestClient(TypecodeReader.BaseUrl), "users/1/todos"));

            Assert.That(AllTodosService.Status, Is.EqualTo("OK"));
        }

        [Test]
        public void ReturnsAllTodos()
        {
            AllTodosService = new TypecodeAPIServices<TodosDTO[]>(new UsersAPIRunner(new RestClient(TypecodeReader.BaseUrl), "users/1/todos"));

            Assert.That(AllTodosService.results.Length, Is.GreaterThan(1));
            Assert.That(AllTodosService.results.Length, Is.EqualTo(20));
        }

        [TestCase(1, 1, "delectus aut autem", false)]
        [TestCase(1, 2, "quis ut nam facilis et officia qui", false)]
        [TestCase(1, 3, "fugiat veniam minus", false)]
        [TestCase(1, 4, "et porro tempora", true)]
        public void CheckThat_TodosValues_ForUserOne_Are_Correct(int userID, int postID, string expectedTitle, bool isCompleted)
        {
            AllTodosService = new TypecodeAPIServices<TodosDTO[]>(new UsersAPIRunner(new RestClient(TypecodeReader.BaseUrl), "users/1/todos"));

            Assert.That(AllTodosService.results[postID - 1].userId, Is.EqualTo(userID));
            Assert.That(AllTodosService.results[postID-1].title, Is.EqualTo(expectedTitle));
            Assert.That(AllTodosService.results[postID - 1].id, Is.EqualTo(postID));
            Assert.That(AllTodosService.results[postID - 1].completed, Is.EqualTo(isCompleted));
        }

        [Test]
        public void CheckThatAll_Todos_ValueTypes_AreCorrect()
        {
            AllTodosService = new TypecodeAPIServices<TodosDTO[]>(new UsersAPIRunner(new RestClient(TypecodeReader.BaseUrl), "users/1/todos"));

            foreach (var item in AllTodosService.results)
            {
                Assert.That(item.title.GetType(), Is.EqualTo(typeof(string)));
                Assert.That(item.id.GetType(), Is.EqualTo(typeof(int)));
                Assert.That(item.completed.GetType(), Is.EqualTo(typeof(bool)));
            }
        }
    }
}
