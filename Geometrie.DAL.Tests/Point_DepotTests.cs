using Geometrie.BLL;
using Geometrie.BLL.Depots;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.DAL.Tests
{
    public class Point_DepotTests
    {
        //on teste la classe Point_Depot en entier
        //on va tester les méthodes Add, Delete, GetAll, GetById, Update
        //on va tester les cas normaux et les cas d'erreurs
        [Fact]
        public void Geometrie_DAL_Point_Depot_Add()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                //arrange
                var depot = new Point_Depot(context);
                var point = new Point(1, 2);

                //Act
                var result = depot.Add(point);

                //Assert
                Assert.NotNull(result);
                Assert.NotNull(result.Id);
                Assert.Equal(1, result.X);
                Assert.Equal(2, result.Y);
            }
        }

        [Fact]
        public void Geometrie_DAL_Point_Depot_Add_ArgumentNullException()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Point_Depot(context);

                //Act & Assert
                Assert.Throws<ArgumentNullException>(() => depot.Add(null));
            }
        }

        [Fact]
        public void Geometrie_DAL_Point_Depot_Delete()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Point_Depot(context);
                var point = new Point(1, 2);
                depot.Add(point);

                //Act
                var result=depot.Delete(point);

                //Assert
                Assert.Same(depot, result);
            }
        }

        [Fact]
        public void Geometrie_DAL_Point_Depot_Delete_ArgumentNullException()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Point_Depot(context);

                //Act & Assert
                Assert.Throws<ArgumentNullException>(() => depot.Delete(null));
            }
        }

        [Fact]
        public void Geometrie_DAL_Point_Depot_Delete_ArgumentNullException_Id()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Point_Depot(context);
                var point = new Point(1, 2);

                //Act & Assert
                Assert.Throws<ArgumentNullException>(() => depot.Delete(point));
            }
        }

        [Fact]
        public void Geometrie_DAL_Point_Depot_Delete_ArgumentException()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Point_Depot(context);

                //Act & Assert
                Assert.Throws<ArgumentException>(() => depot.Delete(0));
            }
        }

        [Fact]
        public void Geometrie_DAL_Point_Depot_GetAll()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Point_Depot(context);
                var point = new Point(1, 2);
                depot.Add(point);

                //Act
                var result = depot.GetAll();

                //Assert
                Assert.NotNull(result);
                Assert.NotEmpty(result);
                Assert.Contains(result, p => p.X == 1 && p.Y == 2);
            }
        }

        [Fact]
        public void Geometrie_DAL_Point_Depot_GetById()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Point_Depot(context);
                var point = new Point(1, 2);
                var addedPoint = depot.Add(point);

                //Act
                var result = depot.GetById(addedPoint.Id.Value);

                //Assert
                Assert.NotNull(result);
                Assert.Equal(1, result.X);
                Assert.Equal(2, result.Y);
            }
        }

        [Fact]
        public void Geometrie_DAL_Point_Depot_Update()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Point_Depot(context);
                var point = new Point(1, 2);
                var addedPoint = depot.Add(point);
                
                var updatedPoint = new Point(addedPoint.Id.Value, 3, 4);
                
                //Act
                var result = depot.Update(updatedPoint);

                //Assert
                Assert.NotNull(result);
                Assert.Equal(3, result.X);
                Assert.Equal(4, result.Y);
            }
        }

        [Fact]
        public void Geometrie_DAL_Point_Depot_Update_ArgumentNullException()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Point_Depot(context);

                //Act & Assert
                Assert.Throws<ArgumentNullException>(() => depot.Update(null));
            }
        }

        [Fact]
        public void Geometrie_DAL_Point_Depot_Update_ArgumentNullException_Id()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Point_Depot(context);
                var point = new Point(1, 2);

                //Act & Assert
                Assert.Throws<ArgumentNullException>(() => depot.Update(point));
            }
        }

        [Fact]
        public void Geometrie_DAL_Point_Depot_Update_ArgumentException_Id()
        {
            //Arrange
            using (var context = new GeometrieContext())
            {
                var depot = new Point_Depot(context);
                var point = new Point(int.MaxValue, 1, 2); //on met un id qui n'existe pas (le dernier possible dans la BDD)

                //Act & Assert
                Assert.Throws<ArgumentException>(() => depot.Update(point));
            }
        }
    }
}
