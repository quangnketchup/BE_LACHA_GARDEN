using BussinessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ViewModels
{
    public class RoomViewModel
    {
        public IBuildingRepository BuildingRepository { get; set; }
        public ICustomerRepository customerRepository { get; set; }
        public IRoomRepository RoomRepository { get; set; }

        public RoomViewModel(ICustomerRepository customerRepository, IRoomRepository roomRepository, IBuildingRepository BuildingRepository)
        {
            this.customerRepository = customerRepository;
            this.RoomRepository = roomRepository;
            this.BuildingRepository = BuildingRepository;
        }
    }
}