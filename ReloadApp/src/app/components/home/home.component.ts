import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from '../../models/Post.model';
import { PostService } from '../../services/post.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  posts:Post[] = [];


  constructor(private router:Router,
              private postService:PostService ) {
  }


  ngOnInit() {
    // this.posts = this.postService.getRecientes();
  }
  crearPost(){
    this.router.navigate(['/crear/post'])

  }

  
}
