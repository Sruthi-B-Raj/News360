import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { News } from '../models/news';

@Injectable({
  providedIn: 'root'
})
export class NewsService {
   //API_KEY = "c2d372ae310c441cb1f84308f9ea8a27";
 // API_KEY = "bc360d447cad4bf5842104070f251aed";
 API_KEY = "8ef68669556f47d0bb7689c1c4d88786";
 // API_KEY = "db645d25c288474a9ed85cb3d6d3692f";

  constructor(private http : HttpClient) { }
  public initArticles(){
    return this.http.get('https://newsapi.org/v2/sources?language=en&apiKey='+this.API_KEY);
  }
  public initSources(){
    return this.http.get('https://newsapi.org/v2/top-headlines?country=in&category=general&apiKey='+this.API_KEY);
  }
  initCategory(){
    return this.http.get('https://newsapi.org/v2/top-headlines?country=us&category=business&apiKey='+this.API_KEY);
   }

   initAll(){
    return this.http.get('https://newsapi.org/v2/everything?sources=bbc-news&apiKey='+this.API_KEY);
   }
   public addToFavourite(favourite: News): Observable<News> {
    var tokenHeader=new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('token')});
     //,{headers : tokenHeader}
     return this.http.post<News>('http://localhost:50496/api/Favourite', favourite, { headers: tokenHeader });
  }
  public getFavourites(userId : any): Observable<News[]> {
    var tokenHeader=new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('token')});
    //,{headers : tokenHeader}
    return this.http.get<News[]>('http://localhost:50496/api/Favourite/' + userId, { headers: tokenHeader } );
  }
  public myfavourites(){
    var tokenHeader=new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('token')});
    //,{headers : tokenHeader}
    return this.http.get('http://localhost:50496/api/Favourite', { headers: tokenHeader });
  }

  deleteFavourite(id,title):Observable<any>{
    var tokenHeader=new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('token')});
   // ,{headers : tokenHeader}
    return this.http.delete<any>('http://localhost:50496/api/Favourite/' + id + '/' + title, { headers: tokenHeader });
  }
  searchNews(search : string){
    return this.http.get('https://newsapi.org/v2/everything?q='+search+'&apiKey='+this.API_KEY);
  }
  public getRecommends() {
    var tokenHeader = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') });
    return this.http.get('http://localhost:62242/api/Recommends', { headers: tokenHeader });
  }
  public addRecommend(rec: News): Observable<News>{
    var tokenHeader = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') });
    return this.http.post<News>('http://localhost:62242/api/Recommends', rec, { headers: tokenHeader });
  }
}
