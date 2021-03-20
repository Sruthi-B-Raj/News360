import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
   //API_KEY = "c2d372ae310c441cb1f84308f9ea8a27";
  // API_KEY = "bc360d447cad4bf5842104070f251aed";
 // API_KEY = "8ef68669556f47d0bb7689c1c4d88786";
  API_KEY = "db645d25c288474a9ed85cb3d6d3692f";

  constructor(private http : HttpClient) { }
 
  public getBusiness(){
    return this.http.get(`https://newsapi.org/v2/top-headlines?country=in&category=business&apiKey=${this.API_KEY}`);
  }
  
  public getEntertainment(){
    return this.http.get(`https://newsapi.org/v2/top-headlines?country=in&category=entertainment&apiKey=${this.API_KEY}`);
  }

  
  public getHealth(){
    return this.http.get(`https://newsapi.org/v2/top-headlines?country=in&category=health&apiKey=${this.API_KEY}`);
  }

  
  public getSPorts(){
    return this.http.get(`https://newsapi.org/v2/top-headlines?country=in&category=sports&apiKey=${this.API_KEY}`);
  }

  
  public getScience(){
    return this.http.get(`https://newsapi.org/v2/top-headlines?country=in&category=science&apiKey=${this.API_KEY}`);
  }

  
  public getTechnology(){
    return this.http.get(`https://newsapi.org/v2/top-headlines?country=in&category=technology&apiKey=${this.API_KEY}`);
  }

  
  public getGeneral(){
    return this.http.get(`https://newsapi.org/v2/top-headlines?country=in&category=general&apiKey=${this.API_KEY}`);
  }


}
