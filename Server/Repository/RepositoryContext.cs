using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

public class RepositoryContext(DbContextOptions<RepositoryContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Enrolment> Enrolments { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<StudentLesson> StudentLessons { get; set; }
    public DbSet<QuizAttempt> QuizAttempts { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply configurations
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new ModuleConfiguration());
        modelBuilder.ApplyConfiguration(new LessonConfiguration());
        modelBuilder.ApplyConfiguration(new QuizConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionConfiguration());
        modelBuilder.ApplyConfiguration(new AnswerConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new EnrolmentConfiguration());
        modelBuilder.ApplyConfiguration(new StudentLessonConfiguration());
        modelBuilder.ApplyConfiguration(new QuizAttemptConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        // Course Configuration
        modelBuilder.Entity<Course>()
            .HasKey(c => c.Id);
        modelBuilder.Entity<Course>()
            .Property(c => c.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Modules)
            .WithOne(m => m.Course)
            .HasForeignKey(m => m.CourseId);

        modelBuilder.Entity<Course>()
        .HasMany(c => c.Quizzes)
        .WithOne(q => q.Course)
        .HasForeignKey(q => q.CourseId);

        modelBuilder.Entity<Course>()
        .HasMany(c => c.Enrolments)
        .WithOne(e => e.Course)
        .HasForeignKey(e => e.CourseId);

        // Enrolment configuration

        modelBuilder.Entity<Enrolment>()
        .HasKey(e => e.Id);

        modelBuilder.Entity<Enrolment>()
        .HasOne(e => e.Course)
        .WithMany(c => c.Enrolments)
        .HasForeignKey(c => c.CourseId);

        modelBuilder.Entity<Enrolment>()
        .HasOne(e => e.Student)
        .WithMany(s => s.Enrolments)
        .HasForeignKey(e => e.StudentId);

        // Module Configuration
        modelBuilder.Entity<Module>()
            .HasKey(m => m.Id);
        modelBuilder.Entity<Module>()
            .HasOne(m => m.Course)
            .WithMany(c => c.Modules)
            .HasForeignKey(m => m.CourseId);

        modelBuilder.Entity<Module>()
            .HasMany(m => m.Lessons)
            .WithOne(l => l.Module)
            .HasForeignKey(l => l.ModuleId);

        // lessone Configuration
        modelBuilder.Entity<Lesson>()
            .HasKey(l => l.Id);

        modelBuilder.Entity<Lesson>()
            .HasOne(l => l.Module)
            .WithMany(m => m.Lessons)
            .HasForeignKey(l => l.ModuleId);

        modelBuilder.Entity<Lesson>()
            .HasMany(l => l.StudentLessons)
            .WithOne(sl => sl.Lesson)
            .HasForeignKey(sl => sl.LessonId);

        // Quiz Configuration 
        modelBuilder.Entity<Quiz>()
            .HasKey(q => q.Id);

        modelBuilder.Entity<Quiz>()
            .HasOne(q => q.Course)
            .WithMany(c => c.Quizzes)
            .HasForeignKey(q => q.CourseId);

        modelBuilder.Entity<Quiz>()
            .HasMany(q => q.Questions)
            .WithOne(q => q.Quiz)
            .HasForeignKey(q => q.QuizId);

        modelBuilder.Entity<Quiz>()
            .HasMany(q => q.Attempts)
            .WithOne(qa => qa.Quiz)
            .HasForeignKey(qa => qa.QuizId);

        // QuizQuestion Configuration
        modelBuilder.Entity<Question>()
            .HasKey(qq => qq.Id);

        modelBuilder.Entity<Question>()
            .HasOne(qq => qq.Quiz)
            .WithMany(q => q.Questions)
            .HasForeignKey(qq => qq.QuizId);

        modelBuilder.Entity<Question>()
            .HasMany(qq => qq.Answers)
            .WithOne(qa => qa.Question)
            .HasForeignKey(qa => qa.QuestionId);

        // QuizAnswer configuration 
        modelBuilder.Entity<Answer>()
            .HasKey(qa => qa.Id);

        // Student configuration
        modelBuilder.Entity<Student>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<Student>()
            .HasMany(s => s.Enrolments)
            .WithOne(e => e.Student)
            .HasForeignKey(e => e.StudentId);

        modelBuilder.Entity<Student>()
            .HasMany(s => s.QuizAttempts)
            .WithOne(qa => qa.Student)
            .HasForeignKey(qa => qa.StudentId);

        modelBuilder.Entity<Student>()
            .HasMany(s => s.StudentLessons)
            .WithOne(sl => sl.Student)
            .HasForeignKey(sl => sl.StudentId);

        // StudentLesson configuration
        modelBuilder.Entity<StudentLesson>()
            .HasKey(sl => sl.Id);

        modelBuilder.Entity<StudentLesson>()
            .HasOne(sl => sl.Student)
            .WithMany(s => s.StudentLessons)
            .HasForeignKey(sl => sl.StudentId);

        modelBuilder.Entity<StudentLesson>()
            .HasOne(sl => sl.Lesson)
            .WithMany(l => l.StudentLessons)
            .HasForeignKey(sl => sl.LessonId);

        // StudentQuizAttempt configuration
        modelBuilder.Entity<QuizAttempt>()
            .HasKey(qa => qa.Id);

        modelBuilder.Entity<QuizAttempt>()
            .HasOne(qa => qa.Student)
            .WithMany(s => s.QuizAttempts)
            .HasForeignKey(qa => qa.StudentId);

        modelBuilder.Entity<QuizAttempt>()
            .HasOne(qa => qa.Quiz)
            .WithMany(q => q.Attempts)
            .HasForeignKey(qa => qa.QuizId);


    }
}
