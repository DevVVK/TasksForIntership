using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using Users.BLL.DTOModels.DTOForDataBase;
using UsersDAL.Entities;
using UsersDAL.Repositories.UnitOfWorks;

namespace Logon.ViewModels
{
    public class MainVm
    {
        private readonly ObservableCollection<UserProfileDto> _userDataProfiles;
        
        public MainVm()
        {
            _userDataProfiles = new ObservableCollection<UserProfileDto>(GetAllUsers());
        }

        public IEnumerable<UserProfileDto> GetAllUsers()
        {
            using (var dataBase = new UnitOfWork())
            {
                Mapper.Initialize(config => config.CreateMap<UserProfile, UserProfileDto>());

                return Mapper.Map<IEnumerable<UserProfile>, List<UserProfileDto>>(dataBase.Profiles.GetAll());
            }
        }

        public ObservableCollection<UserProfileDto> GetDataProfiles()
        {
            return _userDataProfiles;
        }
    }
}