const gulp = require('gulp');
const requireDir = require('require-dir');
const cleanCSS = require('gulp-clean-css');
const uglify = require('gulp-uglify');
const concat = require('gulp-concat');
const del = require('del');
const sourcemaps = require('gulp-sourcemaps');

requireDir('./gulp');

// Task: CSS Dosyalarını Küçültmek ve Birleştirmek
gulp.task('style', function () {
    return gulp.src('wwwroot/css/*.css') // CSS dosyalarınızın yolu
        .pipe(sourcemaps.init())
        .pipe(concat('styles.min.css')) // Birleştirilen CSS dosyası
        .pipe(cleanCSS())
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest('wwwroot/css/dist')); // Küçültülmüş dosyaların kaydedileceği yol
});

// Task: JavaScript Dosyalarını Küçültmek ve Birleştirmek
gulp.task('script', function () {
    return gulp.src('wwwroot/js/*.js') // JavaScript dosyalarınızın yolu
        .pipe(sourcemaps.init())
        .pipe(concat('scripts.min.js')) // Birleştirilen JS dosyası
        .pipe(uglify())
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest('wwwroot/js/dist')); // Küçültülmüş dosyaların kaydedileceği yol
});

// Task: Vendor (Üçüncü Parti Kütüphaneler)
gulp.task('vendor', function () {
    return gulp.src([
        'node_modules/jquery/dist/jquery.min.js',
        // diğer vendor dosyaları
    ])
        .pipe(concat('vendor.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest('wwwroot/js/dist'));
});

// Task: Temizlik (Önceki build çıktılarının silinmesi)
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

// Task: İzleme (Dosya değişikliklerini izler)
gulp.task('watch', function () {
    gulp.watch('wwwroot/css/*.css', gulp.series('style'));
    gulp.watch('wwwroot/js/*.js', gulp.series('script'));
    // Diğer izleme görevleri
});

// Task: Build ve diğer görevler
gulp.task('build', gulp.series('clean', 'compile', 'watch'));
gulp.task('build:test', gulp.series('build', 'watch'));
gulp.task('live', gulp.series('clean:live', 'build', 'build:push'));

gulp.task('default', gulp.series('clean', 'compile', 'watch'));

gulp.task('product:make', gulp.series('compile:all', 'product'));
gulp.task('live:make', gulp.series('pre:live', 'post:live'));
