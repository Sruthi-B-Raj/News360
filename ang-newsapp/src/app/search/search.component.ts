import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { News } from '../models/news';
import { NewsService } from '../service/news.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  articles : any[];
  gridColumns = 4;
  fav:News;
  @Input() hideFavouriteButton: boolean; 

  constructor(private newsService : NewsService, private routeroutlet : Router) { }

  search : string = "";
  
  ngOnInit(): void {
    this.articles = [];
    this.newsService.initAll().subscribe(lista =>{
      for (let element of lista['articles']) {
        this.articles.push(element);
      }
    });
  }

  loggedIn(){
    return localStorage.getItem('token');
  }
  
  searchNews() {
    this.articles = [];
    this.newsService.searchNews(this.search).subscribe(lista => {
      for (let element of lista['articles']) {
        this.articles.push(element);
      }
    });
  }

  onFav(name: any) {
    if (!this.loggedIn()) {
      this.routeroutlet.navigateByUrl("user/login");
      alert('please login to continue');
    }
    else {
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
      this.newsService.addToFavourite(this.fav).subscribe(
        response => { this.fav.id = response.id; this.fav.isFavourite = true; },
        error => { 'Failed to add' });
    }
  }



}
