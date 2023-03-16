using BussinessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ViewModels
{
    public class TreeViewModel
    {
        public ITreeRepository treeRepository { get; set; }
        public ITreeTypeRepository treeTypeRepository { get; set; }
        public IGardenPackageRepository gardenPackageRepository { get; set; }

        public TreeViewModel(ITreeRepository treeRepository, ITreeTypeRepository treeTypeRepository, IGardenPackageRepository gardenPackageRepository)
        {
            this.treeRepository = treeRepository;
            this.treeTypeRepository = treeTypeRepository;
            this.gardenPackageRepository = gardenPackageRepository;
        }
    }
}