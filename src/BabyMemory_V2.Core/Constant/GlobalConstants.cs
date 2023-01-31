﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyMemory_V2.Constant
{
    public static class GlobalConstants
    {
        //RegisterInputModel
        public const int UserNameMAxLen = 100;
        public const int UserNameMinLen = 4;
        public const int PasswordMinLen = 6;
        public const int PasswordMaxLen = 100;
        public const string NameErrorMsg = "The {0} must be at least {2} and at max {1} characters long.";
        public const string PasswordNotMach = "The password and confirmation password do not match.";

        //User
        public const int UserFullNameMAxLenDb = 254;
        public const int UrlMaxLen = 2048;

        //Child
        public const int UserNameMaxLenDb = 100;

        //Memory
        public const int MemoryNameMaxLen = 254;
        public const int MemoryNameMinLen = 4;
        public const int MemoryDescriptionMaxLen = 2048;
        public const int MemoryDescriptionMinLen = 8;

        //HealthProcedure
        public const int HealthProcedureNameMAxLenDb = 254;
        public const int HealthProcedureNameMinLen = 4;

        //Event
        public const int EventNameMaxLen = 254;
        public const int EventDescriptionMaxLen = 2048;

        //Medicine
        public const int MedicineNameMaxLen = 254;
        public const int MedicineNameMinLen = 4;
        public const int MedicineDescriptionMaxLen = 2048;

        //News
        public const int NewsNameMaxLen = 254;
        public const int NewsDescriptionMaxLen = 2048;
        public const string NewsLogo = "https://static.tildacdn.com/tild6437-3735-4635-a539-346232383864/News.jpg";



        //Shared
        public const int IdGuidMaxLen = 36;
        public const string Administrator = "Administrator";
        public const string User = "User";


        //Other
        public const string UserNameExist = "User alredy exist.";
        public const string ChidenNotDeletedError = "Can not Deleted.";
        public const string NewsAddError = "News is not Addet.";
        public const string ImageName = "Avalible Pic: child1.jpg child2.jpg event.png";
        public static string DefaultPicture = "baby.jpg";
        public static string BirthDateError = "Date cannot be in future";
        public static string EventDateError = "Event date cannot be in the past";
    }
}
