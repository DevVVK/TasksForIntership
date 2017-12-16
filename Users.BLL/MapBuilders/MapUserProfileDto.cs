﻿using System;
using System.Collections.Generic;
using Users.BLL.BusinessModels.Date;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using UsersDAL.Entities;

namespace Users.BLL.MapBuilders
{
    public class MapUserProfileDto : IMapBuilder<UserProfileDto, UserProfile>
    {
        private readonly MapUserDto _mapperUserDto = new MapUserDto();

        private readonly MapPictureDto _mapperPictureDto = new MapPictureDto();

        private DateFormConverter _dateConverter;

        public UserProfileDto GetMapOne(UserProfile source)
        {
            _dateConverter = new DateFormConverter(source.DateBirth);

            var userProfileDto = new UserProfileDto
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Gender = source.Gender,

                Day = _dateConverter.Form.Day,
                Month = _dateConverter.Form.Month,
                Year = _dateConverter.Form.Year,
                
                User = _mapperUserDto.GetMapOne(source.User),
                Picture = _mapperPictureDto.GetMapOne(source.Picture)
            };

            return userProfileDto;
        }

        public List<UserProfileDto> GetMapList(List<UserProfile> source)
        {
            var userProfileDtos = new List<UserProfileDto>();

            source.ForEach(item => userProfileDtos.Add(GetMapOne(item)));

            return userProfileDtos;
        }
    }
}