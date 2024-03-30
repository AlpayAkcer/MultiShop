// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Multishop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes ={"CatalogFullPermission","CatalogReadPermission"}},
            new ApiResource("ResourceDiscount"){Scopes ={"DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){Scopes ={"OrderFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            //Token alldığımız kullanıcının hangi bilgilerine erişim sağlayacağımızı aldık.
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authrity for catalog operations"),
            new ApiScope("DiscountFullPermission","Reading authrity for discount operations"),
            new ApiScope("OrderFullPermission","Reading authrity for order operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                //Siteye giren kullanıcıların kayıt olmadan yapabilecekleri yetkiler ve izinleri
                //Kullanıcı şu an bu ayarlar ile sadece catalog izinlerine sahip. Yani ürünleri görebilir.
                //Sepete ürün ekleme işlemi yapmak istiyor ise o zaman OrderFullPermission eklenmeli veya
                //İndirimlerden yararlanmak istiyor ise o zaman da discountfullpermission eklenmesi gerekiyor.
                ClientId="MultishopVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256()) },
                AllowedScopes={ "DiscountFullPermission" } 
                //=> Orjinali bu şekilde olacak. Hata alması için yukarıdaki ayarı kullanıyorum.

            },
            //Manager yetkileri
            new Client
            {
                ClientId="MultishopManagerId",
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256()) },
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission" }
            },

            //Admin yetkileri
            new Client
            {
                ClientId="MultishopAdminId",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256()) },
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.OpenId},
                AccessTokenLifetime=1000
            }
        };
    }
}