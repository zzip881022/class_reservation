﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reservation_new.Models
{
    public class Repository
    {
        private static List<GuestResponse> responses = new List<GuestResponse>();
        public static IEnumerable<GuestResponse> Responses
        {
            get { return responses; }
        }

        public static void AddRepository(GuestResponse response)
        {
            responses.Add(response);
        }
    }
}
