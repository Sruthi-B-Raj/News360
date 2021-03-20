import { Component, Input, OnInit } from '@angular/core';
import { NewsService } from '../service/news.service';

@Component({
  selector: 'app-favourite',
  templateUrl: './favourite.component.html',
  styleUrls: ['./favourite.component.css']
})
export class FavouriteComponent implements OnInit {
  Favourite: string[]; 
  gridColumns = 4;
  //recommend: Recommends;*
  // @Input() hideFavouriteButton: boolean;

  constructor(private newsService:NewsService) { }

  ngOnInit(): void {
    let userName = localStorage.getItem('currentUser')
    this.newsService.getFavourites(userName).subscribe(
      data => {
        this.Favourite = data as string[];
      }
    );

  }
  delete(title:any)
{
  var userName= localStorage.getItem('currentUser');
  this.newsService.deleteFavourite(userName,title).subscribe(
    data => {
      this.ngOnInit();
    }
  );
}

}
