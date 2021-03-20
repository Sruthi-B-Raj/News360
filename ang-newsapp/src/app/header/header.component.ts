import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { News } from '../models/news';
import { CategoryService } from '../service/category.service';
import { NewsService } from '../service/news.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  mArticles: Array<any>;
  mSources: Array<any>;
  title = 'Card View Demo';
  gridColumns = 4;
  fav: News;
  @Input() hideFavouriteButton: boolean;
  isFavourite = false;
  constructor(private routeroutlet: Router, private categoryService: CategoryService, private newsService: NewsService, private http:HttpClient) { }

  ngOnInit(): void {
    this.newsService.initSources().subscribe((data) => {
      this.mArticles = data['articles'];
    });
    this.newsService.initArticles().subscribe(data => this.mSources = data['sources']);
  }
  general() {
    this.categoryService.getGeneral().subscribe((data) => {
      console.log(data);
      this.mArticles = data['articles'];
    });

  }
  onBusiness() {
    this.categoryService.getBusiness().subscribe((data) => {
      console.log(data);
      this.mArticles = data['articles'];
    
    });
  }
  onSports() {
    this.categoryService.getSPorts().subscribe((data) => {
      console.log(data);
      this.mArticles = data['articles'];
    });
  }

  onHealth() {
    this.categoryService.getHealth().subscribe((data) => {
      console.log(data);
      this.mArticles = data['articles'];
    });
  }

  onTechnology() {
    this.categoryService.getTechnology().subscribe((data) => {
      console.log(data);
      this.mArticles = data['articles'];
    });
  }

  onEntertainment() {
    this.categoryService.getEntertainment().subscribe((data) => {
      console.log(data);
      this.mArticles = data['articles'];
    });
  }

  onScience() {
    this.categoryService.getScience().subscribe((data) => {
      console.log(data);
      this.mArticles = data['articles'];
    });
  }
  loggedIn() {
    return localStorage.getItem('token');
  }

  onLogout() {
    localStorage.removeItem('token');
    alert("logged out successfull");
    this.routeroutlet.navigate(['/']);
  }
  // Observable<any>
  onSearch(searchText){
    return  this.http.get(`https://newsapi.org/v2/everything?q=Apple&from=2020-10-10.search=${searchText}&api_key=a9292e09dec5498e83c6e60786b06ad0&format=json`);
  } 
  
  onFav(name: any)  {
    if (!this.loggedIn()) {
      this.routeroutlet.navigateByUrl("user/login");
      alert('please login to continue');
    }
    else {
      this.isFavourite = true;
      alert('Your news has been added to favourites!');
      this.fav = new News();
      this.fav.publishedAt = name.publishedAt;
      this.fav.SourceName = name.source.name;
      this.fav.title = name.title;
      this.fav.url = name.url;
      this.fav.author = name.author;
      this.fav.urltoImage = name.urlToImage;
      this.fav.description = name.description;
      this.fav.userName = localStorage.getItem('currentUser');
      // this.newsService.addToFavourite(this.fav).subscribe(
      //   response => { this.fav.id = response.id; this.fav.isFavourite = true; },
      //   error => { });
      // return 
      this.newsService.addToFavourite(this.fav).subscribe(data=>{
        console.log(data);
      },
      err=>{
        console.log(err);
      });
    }

  }
  favourite() {
    this.newsService.myfavourites().subscribe((data)=>{
      console.log(data);
     this.mArticles = data['articles'];

    });

  }
  recommend(){
    this.newsService.getRecommends().subscribe(data=>{
      console.log(data);
      this.mArticles=data['articles'];
    });
  }
  search(){
   this.routeroutlet.navigate(['/search']);
  }



}
