import { Component, Input, OnInit } from '@angular/core';
import { News } from '../models/news';
import { CategoryService } from '../service/category.service';
import { NewsService } from '../service/news.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {
  mArticles : Array<any>;
  mSources : Array<any>;
  title = 'Card View Demo';
  gridColumns = 4;
  fav:News;
  rec:News;
  isFavourite = false;
  isRecommend=false;
  
  @Input() hideFavouriteButton: boolean;

  constructor(private newsService:NewsService,private categoryService:CategoryService) { }

  ngOnInit(): void {
    this.newsService.initSources().subscribe((data)=>{
     this.mArticles = data['articles'];
    });
    this.newsService.initArticles().subscribe(data=> this.mSources = data['sources']); 
  }
  onFav(name: any)  {
    // if (!this.loggedIn()) {
    //   this.routeroutlet.navigateByUrl("user/login");
    //   alert('please login to continue');
    // }
    // else {
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
  onRecommend(name:any){
    this.isRecommend = true;
    alert('Thanks for liking our article please do check out recommendation section');
    this.rec = new News();
    this.rec.publishedAt = name.publishedAt;
    this.rec.SourceName = name.source.name;
    this.rec.title = name.title;
    this.rec.url = name.url;
    this.rec.author = name.author;
    this.rec.urltoImage = name.urlToImage;
    this.rec.description = name.description;
    this.rec.userName = localStorage.getItem('currentUser');
    this.newsService.addRecommend(this.rec).subscribe(data=>{
      console.log(data);
    },
    err=>{
      console.log(err);

    });

  }
  onBusiness(){
    this.categoryService.getBusiness().subscribe((data)=>{
      console.log(data);
      this.mArticles = data['articles'];
    });
  }
  onSports(){
    this.categoryService.getSPorts().subscribe((data)=>{
      console.log(data);
      this.mArticles = data['articles'];
    });
  }

  onHealth(){
    this.categoryService.getHealth().subscribe((data)=>{
      console.log(data);
      this.mArticles = data['articles'];
    });
  }

  onTechnology(){
    this.categoryService.getTechnology().subscribe((data)=>{
      console.log(data);
      this.mArticles = data['articles'];
    });
  }

  onEntertainment(){
    this.categoryService.getEntertainment().subscribe((data)=>{
      console.log(data);
      this.mArticles = data['articles'];
    });
  }

  onScience(){
    this.categoryService.getScience().subscribe((data)=>{
      console.log(data);
      this.mArticles = data['articles'];
    });
  }
}

