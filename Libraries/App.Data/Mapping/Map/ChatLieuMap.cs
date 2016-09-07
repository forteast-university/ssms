using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Domain;

namespace App.Data.Mapping
{
    public partial class ChatLieuMap: AppEntityTypeConfiguration<ChatLieu>
    {
        public ChatLieuMap()
        {
            this.ToTable("ChatLieu");
            this.HasKey(c => c.MaChatLieu);
        }
    }
}