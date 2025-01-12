using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppStarter.Shared.Authentication
{
    public static class AuthorizationPolicies
    {
        public const string TodoItemDefault = "TodoItem.Default";
        public const string TodoItemCreate = "TodoItem.Create";
        public const string TodoItemUpdate = "TodoItem.Update";
        public const string TodoItemDelete = "TodoItem.Delete";
        
        public static AuthorizationPolicy CanViewTodoItem()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        }

        public static AuthorizationPolicy CanCreateTodoItem()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        }

        public static AuthorizationPolicy CanUpdateTodoItem()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        }

        public static AuthorizationPolicy CanDeleteTodoItem()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        }
    }
}
