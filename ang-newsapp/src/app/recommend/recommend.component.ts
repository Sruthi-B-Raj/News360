import { Component, OnInit } from '@angular/core';
import { NewsService } from '../service/news.service';

@Component({
  selector: 'app-recommend',
  templateUrl: './recommend.component.html',
  styleUrls: ['./recommend.component.css']
})
export class RecommendComponent implements OnInit {
  Recommend:string[];
  gridColumns = 4;


  constructor(private newsService:NewsService) { }

  ngOnInit(): void {
    this.newsService.getRecommends().subscribe(
      data => {
        this.Recommend = data as string[];
      }
    );

  }

}
