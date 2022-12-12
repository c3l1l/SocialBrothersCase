
var url ="http://localhost:28937/api/";
$(document).ready(function(){

	$("#search_box").toggle();
	$("#search_icon").click(function (e) {
		e.preventDefault();
		if ($("#search_box").val() == "") {
			
			$("#search_box").toggle();
			$("div #content_list").html("");
			getAllPostsAjax();
			
		}
		else{
			
				searchPostsAjax($("#search_box").val());
		}		
		return false;
	});
	getAllPostsAjax();
	getPostsSummaryAjax();
	getAllCategories();
	$("#createMessage").click(function(e){
		e.preventDefault();
		addNewPost();
		return false;	

	})
})

function getAllPostsAjax(){
	//var url="http://localhost:5085/api/post";
	
	var data;
	$.getJSON(url + "post", function( data ) {	
		var items = [];
		$.each( data, function( index, element ) {  	

			var newpost="";
			    newpost='<div class="col-md-3 mb-3" style="text-align: left;">'+
			'<div class="border bg-white text-left shadow-sm blog-posts overflow-hidden">'+
			'<img id="postImage" src="'+element.imagePath+'" style="width:auto; height:100px; display: block; margin: auto;" class="card-img-top img-fluid" >'+
			'<h5 class="card-title text-left my-2 mx-3 fw-bold text-break">'+element.title+'</h5>'+
			'<p class="card-text text-muted mx-3 overflow-hidden" style="font-size: 12px;">'+element.content+'</p>'+   
			'</div></div>';
			$("div #content_list").append(newpost);   

		});

	});
}

function getPostsSummaryAjax(){
	//var url="http://localhost:5085/api/post";
	
	var data;
	$.getJSON(url + "post/", function( data ) {	
		
		var items = [];
		var counter=0;
		$.each( data, function( index, element ) { 
			var newpost="";
			if (counter==4) { return false; }
			if (counter == 2 || counter==4) {
			newpost += '</div><div class="row">';
			}	
			 newpost='<div class="col-sm-6">'+
						'<div class="border bg-white text-left shadow-sm blog-posts mb-3 overflow-hidden">'+
                        '<img src="'+element.imagePath+'" style="width:auto; height:100px; display: block; margin: auto;" class="card-img-top" alt="...">'+
                        '<h5 class="card-title text-left my-2 mx-3">'+element.title+'</h5>'+
                        '<p class="card-text text-muted mx-3" style="font-size: 12px;">'+element.content+'</p>'+    
                      	'</div></div>';
			$("div #content_list_add_page").append(newpost);   
			counter ++;
			console.log(counter);
		});

	});
}
function getAllCategories(){
	//var url ="http://localhost:5085/api/Category";
	var data;
	$.getJSON( url+"Category/", function( data ) {	
		
		var items = [];
		$.each( data, function( index, element ) {  	
			var category="";
			category='<option value="'+element.categoryId+'">'+element.name+'</option>'
			$("#category_list").append(category);

		});

	});
}
function addNewPost(){
	//var url="http://localhost:5085/api/post";
	var data="";
	var token="";	
	var formData=new FormData();
	var x=$("input[type=file]")[0].files[0];
	
	formData.append("Image", x);
	formData.append("Title", $("#postTitle").val());
	formData.append("CategoryId", $("#category_list").val());
	formData.append("Content", $("#contentarea").val());
	alert($("#category_list").val());
	
    token=localStorage.getItem("token");
 	
 	$.ajax({
     url: url+"post",
     headers: {Authorization: token},
     type:"POST",
     data: formData,   
     enctype: 'multipart/form-data',
     contentType: false, 
     processData: false, 
     dataType: 'json',
     complete: function(xhr, statusText){
  if (xhr.status == 401){
              window.location.href = 'jwt-login.html';
        }
     }
});

	
}

function searchPostsAjax(searchString){
	var searchUrl=url+"/search?searchString="+searchString;
	var data;
	$.getJSON( searchUrl, function( data ) {	
		if (data.status==404) {
			
		}
		else{
			$("div #content_list").html("");
		$.each( data, function( index, element ) {  	

			var newpost="";
			    newpost='<div class="col-md-3 mb-3" style="text-align: left;">'+
			'<div class="border bg-white text-left shadow-sm blog-posts overflow-hidden">'+
			'<img id="postImage" src="'+element.imagePath+'" style="width:auto; height:100px; display: block; margin: auto;" class="card-img-top img-fluid" >'+
			'<h5 class="card-title text-left my-2 mx-3 fw-bold text-break">'+element.title+'</h5>'+
			'<p class="card-text text-muted mx-3 overflow-hidden" style="font-size: 12px;">'+element.content+'</p>'+   
			'</div></div>';
			$("div #content_list").append(newpost);   

		});
		}
		// $("div #content_list").html("");
		// $.each( data, function( index, element ) {  	

		// 	var newpost="";
		// 	    newpost='<div class="col-md-3 mb-3" style="text-align: left;">'+
		// 	'<div class="border bg-white text-left shadow-sm blog-posts overflow-hidden">'+
		// 	'<img id="postImage" src="'+element.imagePath+'" style="width:auto; height:100px; display: block; margin: auto;" class="card-img-top img-fluid" >'+
		// 	'<h5 class="card-title text-left my-2 mx-3 fw-bold text-break">'+element.title+'</h5>'+
		// 	'<p class="card-text text-muted mx-3 overflow-hidden" style="font-size: 12px;">'+element.content+'</p>'+   
		// 	'</div></div>';
		// 	$("div #content_list").append(newpost);   

		// });

	}).fail(function(data, textStatus, xhr) {
                 if (data.status==404) {
                 	$("div #content_list").html("");
					$("div #content_list").append("Data not found.");   
                 }
                 console.log("error", data.status);
                 //This shows status message eg. Forbidden
                 console.log("STATUS: "+xhr);
            });
}