using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieApp.BLL;
using MovieApp.DAL;
using MovieApp.Controllers;
using MovieApp.Model;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class MovieControllerTest
    {

        [TestMethod]
        public void list_movies()
        {
            //Arrange
            var controller = new MovieController(new MovieBLL(new MovieRepositoryStub()));
            var expected_result = new List<Movie>();
            var movie = new Movie()
            {
                Id = 1,
                ImageAddress = "imageaddress.jpg",
                Title = "Title",
                Description = "Blockbaster Nr.1",
                Price = 150,
                Genre = "Fantasy",
            };
            expected_result.Add(movie);
            expected_result.Add(movie);
            expected_result.Add(movie);

            //Act

            var result = (ViewResult)controller.ListMovies();
            var result_to_list = (List<Movie>)result.Model;

            //Assert

            Assert.AreEqual(result.ViewName, "");

            for (var i = 0; i < result_to_list.Count; i++)
            {
                Assert.AreEqual(expected_result[i].Id, result_to_list[i].Id);
                Assert.AreEqual(expected_result[i].ImageAddress, result_to_list[i].ImageAddress);
                Assert.AreEqual(expected_result[i].Title, result_to_list[i].Title);
                Assert.AreEqual(expected_result[i].Description, result_to_list[i].Description);
                Assert.AreEqual(expected_result[i].Price, result_to_list[i].Price);
                Assert.AreEqual(expected_result[i].Genre, result_to_list[i].Genre);
            }
        }

        [TestMethod]
        public void add_movie_view()
        {
            //Arrange
            var controller = new MovieController(new MovieBLL(new MovieRepositoryStub()));
            //Act
            var result = (ViewResult)controller.AddMovie();
            //Assert
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void add_movie_OK()
        {
            //Arrange
            var controller = new MovieController(new MovieBLL(new MovieRepositoryStub()));
            var newMovie = new Movie()
            {
                Id = 1,
                ImageAddress = "imageaddress.jpg",
                Title = "Title",
                Description = "Blockbaster Nr.1",
                Price = 150,
                Genre = "Fantasy",
            };

            //Act
            var result = (RedirectToRouteResult)controller.AddMovie(newMovie);
            
            //Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "ListMovies");
        }

        [TestMethod]
        public void add_movie_Validation_Fail()
        {
            //Arrange
            var controller = new MovieController(new MovieBLL(new MovieRepositoryStub()));
            var newMovie = new Movie();
            controller.ViewData.ModelState.AddModelError("Title", "Title field is empty");

            //Act
            var result = (ViewResult)controller.AddMovie(newMovie);

            //Assert
            Assert.IsTrue(result.ViewData.ModelState.Count == 1);
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void add_movie_POST_Fail()
        {
            //Arrange
            var controller = new MovieController(new MovieBLL(new MovieRepositoryStub()));
            var newMovie = new Movie();
            newMovie.Title = "";

            //Act
            var result = (ViewResult)controller.AddMovie(newMovie);

            //Assert
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void view_details_OK()
        {
            //Arrange
            var controller = new MovieController(new MovieBLL(new MovieRepositoryStub()));
            var expected_result = new Movie()
            {
                Id = 1,
                ImageAddress = "movieImageAddress.jpg",
                Title = "Title",
                Description = "Blockbaster",
                Price = 12,
                Genre = "Fantasy"
            };

            //Act
            var actionResult = (ViewResult)controller.Details(1);
            var result = (Movie)actionResult.Model;

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(expected_result.Id, result.Id);
            Assert.AreEqual(expected_result.ImageAddress, result.ImageAddress);
            Assert.AreEqual(expected_result.Title, result.Title);
            Assert.AreEqual(expected_result.Description, result.Description);
            Assert.AreEqual(expected_result.Price, result.Price);
            Assert.AreEqual(expected_result.Genre, result.Genre);
        }

        public void details_Fail()
        {
            //Arrange
            var controller = new MovieController(new MovieBLL(new MovieRepositoryStub()));

            //Act
            var actionResult = (ViewResult)controller.Details(0);

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void edit_movie_view()
        {
            // Arrange
            var controller = new MovieController(new MovieBLL(new MovieRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.EditMovie(1);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void edit_movie_OK()
        {
            // Arrange
            var controller = new MovieController(new MovieBLL(new MovieRepositoryStub()));
            var inMovie = new Movie()
            {
                Id = 1,
                ImageAddress = "movieImageAddress.jpg",
                Title = "Title",
                Description = "Blockbaster",
                Price = 12,
                Genre = "Fantasy"
            };
            // Act
            var result = (RedirectToRouteResult)controller.EditMovie(1, inMovie);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "ListMovies");
        }

        [TestMethod]
        public void edit_movie_Validation_Fail()
        {
            // Arrange
            var controller = new MovieController(new MovieBLL(new MovieRepositoryStub()));
            var inMovie = new Movie();
            controller.ViewData.ModelState.AddModelError("error", "Fail");

            // Act
            var result = (ViewResult)controller.EditMovie(1, inMovie);

            // Assert
            Assert.IsTrue(result.ViewData.ModelState.Count == 1);
            Assert.AreEqual(result.ViewData.ModelState["error"].Errors[0].ErrorMessage, "Fail");
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void edit_POST_Fail()
        {
            // Arrange
            var controller = new MovieController(new MovieBLL(new MovieRepositoryStub()));
            var inMovie = new Movie()
            {
                Id = 1,
                ImageAddress = "movieImageAddress.jpg",
                Title = "Title",
                Description = "Blockbaster",
                Price = 12,
                Genre = "Fantasy"
            };

            // Act
            var result = (ViewResult)controller.EditMovie(1, inMovie);

            // Assert
            Assert.AreEqual(result.ViewName, "");
        }

    }
}
