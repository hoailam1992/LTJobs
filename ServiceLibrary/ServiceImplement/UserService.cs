using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Service;
using BusinessLayer.Common;
using Models;
using System.ServiceModel.Activation;
using System.Collections.ObjectModel;

namespace ServiceLibrary
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public partial class MasterService
    {
        public ReturnType<User> SaveUser(User entity)
        {
            if (entity.Id != 0)
            {
                var UserTemp = GetUserById(entity.Id);
                if (UserTemp.IsSuccess && UserTemp.Result != null)
                {
                    entity.Password = UserTemp.Result.Password;                    
                }
            }
            return (new UserBusinessService()).Save(entity);
        }
        
        public ReturnType<User> GetUserById(long id)
        {
            var result = (new UserBusinessService()).GetById(id);
            if (result.Result != null)
            {
                result.Result.Password = null;
                result.Result.SecurityAnswer = null;
                result.Result.SecurityQuestionId = 0;
                result.Result.Photos = null;
                result.Result.Clients = null;
                result.Result.Deliveries = null;
                result.Result.Products = null;
            }
            return (new UserBusinessService()).GetById(id);
        }
        public ReturnType<User> LoginUser(string user, string password)
        {
            return (new UserBusinessService()).LoginUser(user, password);
        }
        public ReturnType<bool> CheckUserName(string username)
        {
            return (new UserBusinessService()).CheckUserName(username);
        }
        public ReturnType<User> RegisterUser(User entity)
        {
            UserBusinessService UserService = new UserBusinessService();
            if (entity.Products != null)
            {
                Product tempProduct = entity.Products.FirstOrDefault();
                entity.Products = null;
                var ResultUser = UserService.Save(entity);
                if (ResultUser.IsSuccess && ResultUser.Result != null)
                {
                    tempProduct.UserId = ResultUser.Result.Id;
                    tempProduct.Code = "PRD" + ResultUser.Result.Id;
                    ProductBusinessService ProductService = new ProductBusinessService();
                    var ResultProduct = ProductService.Save(tempProduct);
                    if (ResultProduct.IsSuccess && ResultProduct.Result!=null)
                    {
                        ResultUser.Result.Products = new ObservableCollection<Product>();
                        ResultUser.Result.Products.Add(ResultProduct.Result);
                        return ResultUser;
                    }
                    else
                    {
                        UserService.DeleteById(ResultUser.Result.Id);
                        return new ReturnType<User>() { IsSuccess = false, Result = null, ErrorMessage = "Product Save Error" };
                    }
                }
            }else
            if (entity.Deliveries != null)
            {
                Delivery tempDelivery = entity.Deliveries.FirstOrDefault();
                entity.Deliveries = null;
                var ResultUser = UserService.Save(entity);
                if (ResultUser.IsSuccess && ResultUser.Result != null)
                {
                    tempDelivery.UserId = ResultUser.Result.Id;
                    tempDelivery.Code = "DLR" + ResultUser.Result.Id;
                    DeliveryBusinessService ProductService = new DeliveryBusinessService();
                    var ResultProduct = ProductService.Save(tempDelivery);
                    if (ResultProduct.IsSuccess && ResultProduct.Result != null)
                    {
                        ResultUser.Result.Deliveries = new ObservableCollection<Delivery>();
                        ResultUser.Result.Deliveries.Add(ResultProduct.Result);
                        return ResultUser;
                    }
                    else
                    {
                        UserService.DeleteById(ResultUser.Result.Id);
                        return new ReturnType<User>() { IsSuccess = false, Result = null, ErrorMessage = "Delivery Save Error" };
                    }
                }

            }
            else
            if (entity.Clients != null)
            {
                Client tempProduct = entity.Clients.FirstOrDefault();
                entity.Clients = null;
                var ResultUser = UserService.Save(entity);
                if (ResultUser.IsSuccess && ResultUser.Result != null)
                {
                    tempProduct.UserId = ResultUser.Result.Id;
                    tempProduct.Code = "CLT" + ResultUser.Result.Id;
                    ClientBusinessService ProductService = new ClientBusinessService();
                    var ResultProduct = ProductService.Save(tempProduct);
                    if (ResultProduct.IsSuccess && ResultProduct.Result != null)
                    {
                        ResultUser.Result.Clients = new ObservableCollection<Client>();
                        ResultUser.Result.Clients.Add(ResultProduct.Result);
                        return ResultUser;
                    }
                    else {
                        UserService.DeleteById(ResultUser.Result.Id);
                        return new ReturnType<User>() { IsSuccess = false, Result = null,ErrorMessage="Client Save Error" };
                    }
                }

            }
            return new ReturnType<User>();

        }
    }
}
