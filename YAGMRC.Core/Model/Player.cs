﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.Core.Model
{
    public class Player
    {
        #region constructor

        private Player()
        {
        }

        public Player(string name, string email)
        {
            this.Name = name;
            this.EMail = email;
            this.ID = Guid.NewGuid();
        }

        #endregion constructor

        public string Name { get; set; }

        public string EMail { get; set; }

        public Guid ID { get; set; }
    }
}
