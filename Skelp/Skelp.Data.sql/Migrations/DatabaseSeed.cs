using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Skelp.Common.Extensions;
using Skelp.Data.Sql.DAO;

namespace Skelp.Data.Sql.Migrations
{
    //klasa odpowiadająca za wypełnienie testowymi danymi bazę danych
    public class DatabaseSeed
    {
        private readonly SkelpDbContext _context;

        //wstrzyknięcie instancji klasy FoodlyDbContext poprzez konstruktor
        public DatabaseSeed(SkelpDbContext context)
        {
            _context = context;
        }

        //metoda odpowiadająca za uzupełnienie utworzonej bazy danych testowymi danymi
        //kolejność wywołania ma niestety znaczenie, ponieważ nie da się utworzyć rekordu
        //w bazie dnaych bez znajmości wartości klucza obcego
        //dlatego należy zacząć od uzupełniania tabel, które nie posiadają kluczy obcych
        //--OFFTOP
        //w przeciwną stronę działa ręczne usuwanie tabel z wypełnionymi danymi w bazie danych
        //należy zacząć od tabel, które posiadają klucze obce, a skończyć na tabelach, które 
        //nie posiadają
        public void Seed()
        {
            //regiony pozwalają na zwinięcie kodu w IDE
            //nie sa dobrą praktyką, kod w danej klasie/metodzie nie powinien wymagać jego zwijania
            //zastosowałem je z lenistwa nie powinno to mieć miejsca 

            #region CreateUsers

            var userList = BuildUserList();
            //dodanie użytkowników do tabeli User
            _context.User.AddRange(userList);
            //zapisanie zmian w bazie danych
            _context.SaveChanges();

            #endregion

            #region CreateSellers

            var sellerList = BuildSellerList();
            _context.Seller.AddRange(sellerList);
            _context.SaveChanges();

            #endregion

            #region CreateProducts

            var productList = BuildProductList(sellerList);
            _context.Product.AddRange(productList);
            _context.SaveChanges();

            #endregion

            #region CreateOrders

            var orderList = BuildOrderList(userList);
            _context.Order.AddRange(orderList);
            _context.SaveChanges();

            #endregion

            #region CreateProductOrder

            var productOrderList = BuildProductOrderList(orderList, productList);
            _context.ProductOrder.AddRange(productOrderList);
            _context.SaveChanges();

            #endregion

            #region CreateComplainList

            var complainList = BuildComplainList(userList, orderList);
            _context.Complain.AddRange(complainList);
            _context.SaveChanges();

            #endregion
        }

        private IEnumerable<DAO.User> BuildUserList()
        {
            var userList = new List<DAO.User>();
            var user = new DAO.User()
            {
                FirstName = "Pawel",
                LastName = "Szoltysik",
                PhoneNumber = 1111111,
                Email = "pawel.szoltysik@student.po.edu.pl",
                RegistrationDate = DateTime.Now.AddYears(-3),
                BirthDate = new DateTime(2000, 3, 10),
                IsBannedUser = false,

            };
            userList.Add(user);

            var user2 = new DAO.User()
            {
                FirstName = "XDDD",
                LastName = "XD",
                PhoneNumber = 11121111,
                Email = "aaaaa@student.po.edu.pl",
                RegistrationDate = DateTime.Now.AddYears(-2),
                BirthDate = new DateTime(2010, 4, 22),
                IsBannedUser = false
            };
            userList.Add(user2);

            for (int i = 3; i <= 20; i++)
            {
                var user3 = new DAO.User
                {
                    FirstName = "user" + i,
                    LastName = "test" + i,
                    PhoneNumber = 32132232 + i * 44,
                    Email = "user" + i + "@student.po.edu.pl",
                    RegistrationDate = DateTime.Now.AddYears(-2),
                    BirthDate = new DateTime(1994, 6, 7),
                    IsBannedUser = false,

                };
                userList.Add(user3);
            }

            return userList;
        }

        private IEnumerable<Seller> BuildSellerList()
        {
            var sellerList = new List<Seller>();
            var seller = new Seller()
            {
                SellerName = "AOAOAO",
                Nip = 11111111,
                Regon = 11111111,
                Pesel = 11111111,
                CompanyAdress = "Prószkowska 12",
                CompanyEmail = "seller@student.po.edu.pl",
                CompanyIsBanned = false,

            };
            sellerList.Add(seller);


            var seller2 = new Seller()
            {
                SellerName = "Xcom",
                Nip = 11312311,
                Regon = 11124111,
                Pesel = 1111413221,
                CompanyAdress = "ADS 12",
                CompanyEmail = "XkomCostam@student.po.edu.pl",
                CompanyIsBanned = true,
            };
            sellerList.Add(seller2);

            for (int i = 3; i <= 20; i++)
            {
                var seller3 = new Seller()
                {
                    SellerName = "seller" + i,
                    Nip = 11312311 + i * 142,
                    Regon = 11124111 + i * 4234,
                    Pesel = 111141322 + i * 434144,
                    CompanyAdress = "ADS 12" + i,
                    CompanyEmail = "XkomCostam" + i + "@student.po.edu.pl",
                    CompanyIsBanned = true,

                };
                sellerList.Add(seller3);
            }

            return sellerList;
        }

        private IEnumerable<Product> BuildProductList(IEnumerable<Seller> sellerList)
        {
            var productList = new List<Product>();
            var rnd = new Random();
            for (int i = 1; i <= 20; i++)
            { 
                var index = rnd.Next(0, sellerList.Count());
                productList.Add(new Product

                {
                    SellerId = sellerList.ToList()[index].SellerId,
                    ProductName = "product" + i,
                    Brand = "Brand" + i,
                    ProductDescription = "AAFAOPFASO" + i,
                    Price = i * 1.5,
                    Weight = i * 100,


                });

            }
            return productList;
        }


    


        


        private IEnumerable<Order> BuildOrderList(IEnumerable<DAO.User> userList)
        {
            var ordersList = new List<Order>();
            var rnd = new Random();
            foreach (var user in userList)
            {
                var index = rnd.Next(0, userList.Count());
                if (user.FirstName != null)
                {
                    
                    ordersList.Add(new Order
                    {
                        UserId = userList.ToList()[index].UserId,
                        IsPaid = true,
                        DateAcceptance = DateTime.Now.AddDays(-3),
                        Realised = true,
                        DateRealisation = DateTime.Today,

                    });
                }


            }


            return ordersList;
        }

        private IEnumerable<ProductOrder> BuildProductOrderList(
            IEnumerable<Order> orderList,
            IEnumerable<Product> productList)
        {
            var productOrderList = new List<ProductOrder>();
            orderList.ToList().Shuffle();
            productList.ToList().Shuffle();
            var rnd = new Random();
            for (int i = 0; i < orderList.Count(); i++)
            {
                var index = rnd.Next(0, productList.Count());

                productOrderList.Add(new ProductOrder
                {
                    ProductId = productList.ToList()[index].ProductId,
                    OrderId = orderList.ToList()[i].OrderId,
                });

            }

            return productOrderList;
        }

        private IEnumerable<Complain> BuildComplainList(IEnumerable<DAO.User> userList,
            IEnumerable<Order> orderList)
        {
            var complainList = new List<Complain>();
            foreach (var user in userList)
            {
                if (user.FirstName != null)
                {
                    complainList.Add(new Complain
                    {
                        UserId = userList.First().UserId,
                        OrderId = orderList.First().OrderId,
                        Description = "Residence certainly elsewhere something she preferred cordially law. ",

                    });
                }
            }


            return complainList;
        }

    }
}

