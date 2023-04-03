using BussinessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ViewModels
{
    public class ResultViewModels
    {
        public IResultRepository _resultRepository { get; set; }
        public ITreeCareRepository _treeCareRepository { get; set; }

        public ResultViewModels(ITreeCareRepository treeCareRepository, IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
            _treeCareRepository = treeCareRepository;
        }
    }
}