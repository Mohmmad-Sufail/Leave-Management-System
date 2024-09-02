export class Leave {
    id:number=0;
    employeeID: number=0;
    employeeName: string='';
    employeeEmail: string='';
    employeePhone: string='';
    manager: string='';
    employeeAge: number = 0;
    from: Date = new Date();
    to: Date = new Date();
    totaldays: number = 0;
    reason: string='';
    status: string = 'pending';
}
