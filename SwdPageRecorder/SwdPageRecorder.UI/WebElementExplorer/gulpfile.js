var gulp = require('gulp');

var concat = require('gulp-concat');
var livereload = require('gulp-livereload');
 
gulp.task('default', function() {
  gulp.src('./src/*.js')
    .pipe(concat('all.js'))
    .pipe(gulp.dest('./dist/'))
});

gulp.task('watch', function() {
  gulp.watch('./src/*.js', ['default']);
});


