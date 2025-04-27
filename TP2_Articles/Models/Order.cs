﻿using Microsoft.AspNetCore.Identity;

namespace TP2_Articles.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        // Lien avec l'utilisateur dans Identity
        public IdentityUser User { get; set; }
        // Liste des articles de la commande
        public List<OrderItem> Items { get; set; }
        public string UserId { get; set; }
    }
}
