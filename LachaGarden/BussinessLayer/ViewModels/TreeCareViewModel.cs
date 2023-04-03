using BussinessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ViewModels
{
    public class TreeCareViewModel
    {
        public IUserRepository _userRepository { get; set; }
        public IRequestRepository _requestRepository { get; set; }
        public ITreeCareRepository _treeCareRepository { get; set; }

        public TreeCareViewModel(IUserRepository userRepository, IRequestRepository requestRepository, ITreeCareRepository treeCareRepository)
        {
            _userRepository = userRepository;
            _requestRepository = requestRepository;
            _treeCareRepository = treeCareRepository;
        }
    }
}