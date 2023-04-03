using BussinessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ViewModels
{
    public class RequestViewModel
    {
        public IGardenRepository GardenRepository { get; set; }
        public IRequestRepository RequestRepository { get; set; }

        public RequestViewModel(IGardenRepository GardenRepositoryy, IRequestRepository RequestRepository)
        {
            this.GardenRepository = GardenRepositoryy;
            this.RequestRepository = RequestRepository;
        }
    }
}