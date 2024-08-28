const gulp = require('gulp');
const requireDir = require('require-dir');
const cleanCSS = require('gulp-clean-css');
const uglify = require('gulp-uglify');
const concat = require('gulp-concat');
const del = require('del');
const sourcemaps = require('gulp-sourcemaps');

requireDir('./gulp');

// Task: CSS Dosyalar�n� K���ltmek ve Birle�tirmek
gulp.task('style', function () {
    return gulp.src('wwwroot/css/*.css') // CSS dosyalar�n�z�n yolu
        .pipe(sourcemaps.init())
        .pipe(concat('styles.min.css')) // Birle�tirilen CSS dosyas�
        .pipe(cleanCSS())
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest('wwwroot/css/dist')); // K���lt�lm�� dosyalar�n kaydedilece�i yol
});

// Task: JavaScript Dosyalar�n� K���ltmek ve Birle�tirmek
gulp.task('script', function () {
    return gulp.src('wwwroot/js/*.js') // JavaScript dosyalar�n�z�n yolu
        .pipe(sourcemaps.init())
        .pipe(concat('scripts.min.js')) // Birle�tirilen JS dosyas�
        .pipe(uglify())
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest('wwwroot/js/dist')); // K���lt�lm�� dosyalar�n kaydedilece�i yol
});

// Task: Vendor (���nc� Parti K�t�phaneler)
gulp.task('vendor', function () {
    return gulp.src([
        'node_modules/jquery/dist/jquery.min.js',
        // di�er vendor dosyalar�
    ])
        .pipe(concat('vendor.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest('wwwroot/js/dist'));
});

// Task: Temizlik (�nceki build ��kt�lar�n�n silinmesi)
gulp.task('clean', function () {
    return del([
        'wwwroot/css/dist/*',
        'wwwroot/js/dist/*'
    ]);
});

gulp.task('clean:build', function () {
    return del([
        'build/*'
    ]);
});

gulp.task('clean:live', function () {
    return del([
        'live/*'
    ]);
});

// Task: �zleme (Dosya de�i�ikliklerini izler)
gulp.task('watch', function () {
    gulp.watch('wwwroot/css/*.css', gulp.series('style'));
    gulp.watch('wwwroot/js/*.js', gulp.series('script'));
    // Di�er izleme g�revleri
});

// Task: Build ve di�er g�revler
gulp.task('build', gulp.series('clean', 'compile', 'watch'));
gulp.task('build:test', gulp.series('build', 'watch'));
gulp.task('live', gulp.series('clean:live', 'build', 'build:push'));

gulp.task('default', gulp.series('clean', 'compile', 'watch'));

gulp.task('product:make', gulp.series('compile:all', 'product'));
gulp.task('live:make', gulp.series('pre:live', 'post:live'));
