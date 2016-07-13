﻿using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Commands.Admin
{
    class AdminSpawnEnchanted : AAdminCommand
    {
        public AdminSpawnEnchanted()
        {
            Cmd = "summon2";
        }

        protected internal override void Use(L2Player admin, string alias)
        {
            //summon2 [enchant] [id | name] -- призывает предмет [id | name] , заточенный на [enchant]

            short enchant = short.Parse(alias.Split(' ')[1]);
            int id = int.Parse(alias.Split(' ')[2]);
            admin.AddItem(id, 1);
        }
    }
}