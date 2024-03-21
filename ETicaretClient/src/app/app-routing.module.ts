import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './admin/layout/layout.component';
import path from 'path';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { HomeComponent } from './iu/components/products/home/home.component';
import { AuthGuard } from './guards/common/auth.guard';

const routes: Routes = [
  {
    path:"admin",component:LayoutComponent, children:[
      {path:"",component:DashboardComponent},
     { path:"customers",loadChildren:()=>import("./admin/components/customer/customer.module").then(module=>module.CustomerModule)},
     { path:"orders",loadChildren:()=>import("./admin/components/orders/orders.module").then(module=>module.OrdersModule)},
      { path: "products", loadChildren: () => import("./admin/components/products/products.module").then(module => module.ProductsModule) }
    ], canActivate: [AuthGuard]
  },
  {path:"",component:HomeComponent},
  {path:"baskets",loadChildren:()=>import("./iu/components/products/baskets/baskets.module").then(module=>module.BasketsModule)},
  { path: "products", loadChildren: () => import("./iu/components/products/products.module").then(module => module.ProductsModule) },
  { path: "register", loadChildren: () => import("./iu/components/register/register.module").then(module => module.RegisterModule) },
  { path: "login", loadChildren: () => import("./iu/components/login/login.module").then(module => module.LoginModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
