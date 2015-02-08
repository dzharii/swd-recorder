var gulp = require('gulp');

var concat = require('gulp-concat');
 
gulp.task('default', function() {
  gulp.src('./src/*.js')
    .pipe(concat('all.js'))
    .pipe(gulp.dest('./dist/'))
});

/*
gulp.task('default', function() {
  // place code for your default task here
});
*/