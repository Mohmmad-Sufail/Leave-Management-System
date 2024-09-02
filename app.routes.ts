import { Routes } from '@angular/router';
import { LeaveformComponent } from './leaveform/leaveform.component';
import { DisplayComponent } from './display/display.component';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
    {path:'',component:HomeComponent},
    {path:'leaveform',component:LeaveformComponent},
    {path:'display',component:DisplayComponent},
    
    
];
