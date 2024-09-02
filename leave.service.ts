import { Injectable } from '@angular/core';
import { Leave } from './leave.model';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { stringify } from 'querystring';
 
@Injectable({
  providedIn: 'root'
})
export class LeaveService {
  
  constructor(private http: HttpClient) { }
 
  readonly baseURL = 'http://localhost:5138/api/LeaveDetails'
  formData: Leave = new Leave();
  list0: Leave[] | undefined;
  list: Leave[] | undefined;
 
  postLeave() {
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${localStorage.getItem('token')}`
      })
    };
    console.log(this.formData)
    return this.http.post(this.baseURL, this.formData);
  }
 
  putLeave() {
    return this.http.put(`${this.baseURL}/${this.formData.id}`, this.formData);
  }
 
  deleteLeave(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
 
  refreshList() {
    
    this.http.get(this.baseURL)
      .toPromise()
      .then(res => {
        this.list0 = res as Leave[]
        this.list = res as Leave[]
      });
      console.log("RefreshList",this.list);
      
  }

  modifyList(txt: string){
    this.list = this.list0?.filter((item) => item.employeeID.toString() == txt || item.employeeName.includes(txt) || item.status.includes(txt));
  }
}