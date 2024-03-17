import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject, observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  Course } from './model';
import { tap, map } from 'rxjs/operators';

const CREATE_ACTION = 'addcourse';
const UPDATE_ACTION = 'updatecourse';

@Injectable()
export class EditService extends BehaviorSubject<Course[]> {
    constructor(private http: HttpClient) {
        super([]);
    }

    private data: Course[]= [];

    public read(): void {
        if (this.data.length) {
            return super.next(this.data);
        }

        this.fetch()
            .pipe(
                tap(data => {
                    this.data = data;
                })
            )
            .subscribe(data => {
                super.next(data);
            });
    }

    public save(data: Course[], isNew?: boolean): void {
        const action = isNew ? CREATE_ACTION : UPDATE_ACTION;

        this.reset();

        this.update( data,action)
            .subscribe(() => this.read(), () => this.read());
    }

    public remove(data: Course []): void {
        this.reset();

        this.delete(data)
            .subscribe(() => this.read(), () => this.read());
    }

    public resetItem(dataItem: Course): void {
        if (!dataItem) { return; }

        // find orignal data item
        const originalDataItem = this.data.find(item => item.CourseId === dataItem.CourseId);

        // revert changes
        Object.assign(originalDataItem, dataItem);

        super.next(this.data);
    }

    private reset() {
        this.data = [];
    }

    private fetch(action = "", data?: Course[]): Observable<Course[]> {
        return this.http
          .get(
                `https://localhost:44353/academiccourses/getcourses`)
          .pipe(map((res: Object) => <Course[]>res));
      }
    

    private update(data?:Course[],action=""):Observable<Course[]> {
       
        let body = JSON.stringify(data);
         let headers = new HttpHeaders({'Content-Type': 'application/json'});
        const  options ={
                headers:headers
      }
      const res=  this.http.post<any>(`https://localhost:44353/academiccourses/${action}`,body   ,options)  
        .pipe(map((res: Object) => <Course[]>res));
        return res;
    }


    private delete(data?:Course[]):Observable<Course[]> {
        
        
        let body = JSON.stringify(data);
         let headers = new HttpHeaders({'Content-Type': 'application/json'});
        const  options ={
                headers:headers
      }
    
   
    const res=  this.http.post<any>(`https://localhost:44353/academiccourses/deletecourse`,body   ,options)  
    .pipe(map((res: Object) => <Course[]>res));
        return res;
    }
   
}
