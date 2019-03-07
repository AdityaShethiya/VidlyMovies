using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyMovies.Models;

namespace VidlyMovies.ViewModel
{
    public class MoviesVm
    {
        public int CustmerId { get; set; }
        public string CustmerName { get; set; }
        public IEquatable<MembershipType> MembershipTypes { get; set; }
        public string DateOfBirth { get; set; }
        public string SignupFree { get; set; }

    }
}