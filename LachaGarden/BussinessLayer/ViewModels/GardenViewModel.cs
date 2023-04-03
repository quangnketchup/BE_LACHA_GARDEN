using BussinessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ViewModels
{
    public class GardenViewModel
    {
        public IGardenPackageRepository GardenPackageRepository { get; set; }
        public IGardenRepository GardenRepository { get; set; }
        public IRoomRepository RoomRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }

        public GardenViewModel(ICustomerRepository CustomerRepository, IGardenPackageRepository GardenPackageRepository, IGardenRepository GardenRepository, IRoomRepository RoomRepository)
        {
            this.GardenPackageRepository = GardenPackageRepository;
            this.GardenRepository = GardenRepository;
            this.RoomRepository = RoomRepository;
            this.CustomerRepository = CustomerRepository;
        }
    }
}