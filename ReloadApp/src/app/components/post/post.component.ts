import { Component, OnInit, Input } from '@angular/core';
import { Post } from 'src/app/models/Post.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  @Input()post:Post;

  constructor(private router:Router) { 
    


  }   

  categoria:string;  
  
  ngOnInit() {
  }

  irPost(){
    this.router.navigate(['/post', this.post._id]);
  }
}
