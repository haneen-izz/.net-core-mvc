using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace finalProject.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Audit> Audits { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contactinfo> Contactinfos { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Customer1> Customer1s { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Department1> Departments1 { get; set; }
        public virtual DbSet<Department2> Departments2 { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee1> Employee1s { get; set; }
        public virtual DbSet<Employee2> Employees1 { get; set; }
        public virtual DbSet<Employee21> Employee2s { get; set; }
        public virtual DbSet<Employee3> Employees2 { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Patientmedicine> Patientmedicines { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Position1> Positions1 { get; set; }
        public virtual DbSet<ProAbout> ProAbouts { get; set; }
        public virtual DbSet<ProCategory> ProCategories { get; set; }
        public virtual DbSet<ProContact> ProContacts { get; set; }
        public virtual DbSet<ProHomepage> ProHomepages { get; set; }
        public virtual DbSet<ProLoginandreg> ProLoginandregs { get; set; }
        public virtual DbSet<ProOrder> ProOrders { get; set; }
        public virtual DbSet<ProPayment> ProPayments { get; set; }
        public virtual DbSet<ProProduct> ProProducts { get; set; }
        public virtual DbSet<ProProductOrder> ProProductOrders { get; set; }
        public virtual DbSet<ProReview> ProReviews { get; set; }
        public virtual DbSet<ProRole> ProRoles { get; set; }
        public virtual DbSet<ProTestimonial> ProTestimonials { get; set; }
        public virtual DbSet<ProUser> ProUsers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Productcustomer> Productcustomers { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Supplier1> Suppliers1 { get; set; }
        public virtual DbSet<Userlogin> Userlogins { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=TAH10_USER121;PASSWORD=1234;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TAH10_USER121")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountNum);

                entity.ToTable("ACCOUNT");

                entity.Property(e => e.AccountNum)
                    .HasPrecision(5)
                    .HasColumnName("ACCOUNT_NUM");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER(15,2)")
                    .HasColumnName("BALANCE")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.BankNum)
                    .HasPrecision(5)
                    .HasColumnName("BANK_NUM");

                entity.Property(e => e.CustomerId)
                    .HasPrecision(5)
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.HasOne(d => d.BankNumNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.BankNum)
                    .HasConstraintName("FK_BANK_ACCOUNT");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_BANK_CUSTOMER");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("ADDRESS");

                entity.Property(e => e.AddressId)
                    .HasPrecision(10)
                    .HasColumnName("ADDRESS_ID");

                entity.Property(e => e.Addressname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESSNAME");
            });

            modelBuilder.Entity<Audit>(entity =>
            {
                entity.ToTable("AUDITS");

                entity.Property(e => e.AuditId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AUDIT_ID");

                entity.Property(e => e.ByUser)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BY_USER");

                entity.Property(e => e.TableName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TABLE_NAME");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("DATE")
                    .HasColumnName("TRANSACTION_DATE");

                entity.Property(e => e.TransactionName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_NAME");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.BankNum);

                entity.ToTable("BANK");

                entity.Property(e => e.BankNum)
                    .HasPrecision(5)
                    .HasColumnName("BANK_NUM");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.BankName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BANK_NAME");

                entity.Property(e => e.PhoneNo)
                    .HasPrecision(10)
                    .HasColumnName("PHONE_NO");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");
            });

            modelBuilder.Entity<Contactinfo>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("SYS_C00100672");

                entity.ToTable("CONTACTINFO");

                entity.Property(e => e.ContactId)
                    .HasPrecision(10)
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.AddressId)
                    .HasPrecision(10)
                    .HasColumnName("ADDRESS_ID");

                entity.Property(e => e.Phonenumber)
                    .HasPrecision(10)
                    .HasColumnName("PHONENUMBER");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Contactinfos)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_ADDRESS_CON");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMER");

                entity.Property(e => e.CustomerId)
                    .HasPrecision(5)
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.BankNum)
                    .HasPrecision(5)
                    .HasColumnName("BANK_NUM");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT_NUMBER");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME");

                entity.HasOne(d => d.BankNumNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.BankNum)
                    .HasConstraintName("FK_CUSTOMER");
            });

            modelBuilder.Entity<Customer1>(entity =>
            {
                entity.ToTable("CUSTOMER1");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");
            });

            modelBuilder.Entity<Department1>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("SYS_C00100669");

                entity.ToTable("DEPARTMENT__");

                entity.Property(e => e.DepartmentId)
                    .HasPrecision(10)
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.AddressId)
                    .HasPrecision(10)
                    .HasColumnName("ADDRESS_ID");

                entity.Property(e => e.Departmentname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENTNAME");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Department1s)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_ADDRESS");
            });

            modelBuilder.Entity<Department2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DEPARTMENT_");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SALARY");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Employee1>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("EMPLOYEE2_PK");

                entity.ToTable("EMPLOYEE1");

                entity.HasIndex(e => e.PhoneNo, "UNI_NUM")
                    .IsUnique();

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(4)
                    .HasColumnName("EMPLOYEE_NAME");

                entity.Property(e => e.PhoneNo)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PHONE_NO");

                entity.Property(e => e.PosId)
                    .HasColumnType("NUMBER(30)")
                    .HasColumnName("POS_ID");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(30)")
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.Employee1s)
                    .HasForeignKey(d => d.PosId)
                    .HasConstraintName("POSITION_FK");
            });

            modelBuilder.Entity<Employee2>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK_EMPLOYEE");

                entity.ToTable("EMPLOYEE_");

                entity.Property(e => e.EmployeeId)
                    .HasPrecision(5)
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.DateOfDeployment)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_OF_DEPLOYMENT");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_NAME");

                entity.Property(e => e.PositionId)
                    .HasPrecision(5)
                    .HasColumnName("POSITION_ID");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employee2s)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_POSITION");
            });

            modelBuilder.Entity<Employee21>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("SYS_C00100675");

                entity.ToTable("EMPLOYEE2");

                entity.Property(e => e.EmployeeId)
                    .HasPrecision(10)
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.ContactId)
                    .HasPrecision(10)
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.DepartmentId)
                    .HasPrecision(10)
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.Employeename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEENAME");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Employee21s)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_CONTACT_");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee21s)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_EMP_");
            });

            modelBuilder.Entity<Employee3>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("SYS_C0094521");

                entity.ToTable("EMPLOYEE__");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee3s)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_DEPARTMENT");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("MEDICINE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Patientname)
                    .HasName("PATIENT_PK");

                entity.ToTable("PATIENT");

                entity.Property(e => e.Patientname)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PATIENTNAME");

                entity.Property(e => e.Patientnumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PATIENTNUMBER");

                entity.HasOne(d => d.PatientnameNavigation)
                    .WithOne(p => p.Patient)
                    .HasForeignKey<Patient>(d => d.Patientname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ID");
            });

            modelBuilder.Entity<Patientmedicine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PATIENTMEDICINE");

                entity.Property(e => e.Column1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COLUMN1");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("POSITION");

                entity.Property(e => e.PositionId)
                    .HasColumnType("NUMBER(30)")
                    .HasColumnName("POSITION_ID");

                entity.Property(e => e.PositionName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POSITION_NAME");
            });

            modelBuilder.Entity<Position1>(entity =>
            {
                entity.HasKey(e => e.PositionId)
                    .HasName("PK_BAN");

                entity.ToTable("POSITION_");

                entity.Property(e => e.PositionId)
                    .HasPrecision(5)
                    .HasColumnName("POSITION_ID");

                entity.Property(e => e.BankNum)
                    .HasPrecision(5)
                    .HasColumnName("BANK_NUM");

                entity.Property(e => e.PositionName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POSITION_NAME");

                entity.HasOne(d => d.BankNumNavigation)
                    .WithMany(p => p.Position1s)
                    .HasForeignKey(d => d.BankNum)
                    .HasConstraintName("FK_BANK");
            });

            modelBuilder.Entity<ProAbout>(entity =>
            {
                entity.HasKey(e => e.AboutId)
                    .HasName("SYS_C00125719");

                entity.ToTable("PRO_ABOUT");

                entity.Property(e => e.AboutId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ABOUT_ID");

                entity.Property(e => e.Text2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TEXT2");
            });

            modelBuilder.Entity<ProCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("SYS_C00125671");

                entity.ToTable("PRO_CATEGORY");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");

                entity.Property(e => e.Image)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");
            });

            modelBuilder.Entity<ProContact>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("SYS_C00125714");

                entity.ToTable("PRO_CONTACT");

                entity.Property(e => e.ContactId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.Age)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("AGE");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Phone)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PHONE");



            });

            modelBuilder.Entity<ProHomepage>(entity =>
            {
                entity.ToTable("PRO_HOMEPAGE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AboutId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ABOUT_ID");

                entity.Property(e => e.ContactId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CONTACT_ID");

                entity.HasOne(d => d.About)
                    .WithMany(p => p.ProHomepages)
                    .HasForeignKey(d => d.AboutId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PRO_ABOUT_FK");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ProHomepages)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PRO_CONTACT_FK");

                entity.Property(e => e.Image)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");


            });

            modelBuilder.Entity<ProLoginandreg>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("SYS_C00125676");

                entity.ToTable("PRO_LOGINANDREG");

                entity.Property(e => e.LoginId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ProLoginandregs)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("PRO_USER_FK");
            });

            modelBuilder.Entity<ProOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("SYS_C00125686");

                entity.ToTable("PRO_ORDER");

                entity.Property(e => e.OrderId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.OrdersDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ORDERS_DATE");


                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("QUANTITY");

                entity.Property(e => e.Sales)
                    .HasColumnType("FLOAT")
                    .HasColumnName("SALES");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProOrders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PRO_USER2_FK");
            });

            modelBuilder.Entity<ProPayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("SYS_C00125706");

                entity.ToTable("PRO_PAYMENT");

                entity.Property(e => e.PaymentId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAYMENT_ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.CardExp)
                    .HasColumnType("DATE")
                    .HasColumnName("CARD_EXP");

                entity.Property(e => e.CardName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CARD_NAME");

                entity.Property(e => e.CardNum)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CARD_NUM");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProPayments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PRO_USER3_FK");
            });

            modelBuilder.Entity<ProProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("SYS_C00125683");

                entity.ToTable("PRO_PRODUCT");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Cost)
                    .HasColumnType("FLOAT")
                    .HasColumnName("COST");

                entity.Property(e => e.Image)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_NAME");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("QUANTITY");

                entity.Property(e => e.Sale)
                    .HasColumnType("FLOAT")
                    .HasColumnName("SALE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProProducts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("PRO_FK_CATE");
            });

            modelBuilder.Entity<ProProductOrder>(entity =>
            {
                entity.ToTable("PRO_PRODUCT_ORDER");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.OrderId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProProductOrders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PRO_ORDER2_FK");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProProductOrders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PRO_PRODUCT2_FK");
            });

            modelBuilder.Entity<ProReview>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("SYS_C00125711");

                entity.ToTable("PRO_REVIEW");

                entity.Property(e => e.ReviewId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("REVIEW_ID");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Rating)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("RATING");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProReviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00125712");
            });

            modelBuilder.Entity<ProRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("SYS_C00125674");

                entity.ToTable("PRO_ROLE");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<ProTestimonial>(entity =>
            {
                entity.HasKey(e => e.TestimonialId)
                    .HasName("SYS_C00125716");

                entity.ToTable("PRO_TESTIMONIAL");

                entity.Property(e => e.TestimonialId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIAL_ID");

                entity.Property(e => e.TestimonialText)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TESTIMONIAL_TEXT");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProTestimonials)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("TESTI_CUS_FK");
            });

            modelBuilder.Entity<ProUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("SYS_C00125679");

                entity.ToTable("PRO_USER");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Image)
                         .HasMaxLength(50)
                         .IsUnicode(false)
                         .HasColumnName("IMAGE");
                entity.Property(e => e.Password)
                                    .HasMaxLength(50)
                                    .IsUnicode(false)
                                    .HasColumnName("PASSWORD");
                entity.Property(e => e.Phone)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PHONE");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLE_ID");


                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ProUsers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("PRO_ROLE_FK");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Price)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Sale)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SALE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK_CATEGORY");
            });

            modelBuilder.Entity<Productcustomer>(entity =>
            {
                entity.ToTable("PRODUCTCUSTOMER");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Customerid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMERID");

                entity.Property(e => e.Datefrom)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEFROM");

                entity.Property(e => e.Dateto)
                    .HasColumnType("DATE")
                    .HasColumnName("DATETO");

                entity.Property(e => e.Productid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCTID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUANTITY");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Productcustomers)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("FK_CUSTOMER1_PRODUCT");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productcustomers)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("FK_PRODUCT");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("REPORT");

                entity.Property(e => e.ReportId)
                    .HasPrecision(5)
                    .HasColumnName("REPORT_ID");

                entity.Property(e => e.BankNum)
                    .HasPrecision(5)
                    .HasColumnName("BANK_NUM");

                entity.Property(e => e.ReportDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REPORT_DATE");

                entity.Property(e => e.ReportName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REPORT_NAME");

                entity.HasOne(d => d.BankNumNavigation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.BankNum)
                    .HasConstraintName("FK_BANK_REPORT");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("ROOM");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("SUPPLIERS");

                entity.Property(e => e.SupplierId)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("SUPPLIER_ID");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(100)
                    .HasColumnName("SUPPLIER_NAME");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<Supplier1>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("SUP_PK");

                entity.ToTable("SUPPLIER");

                entity.Property(e => e.SupplierId)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("SUPPLIER_ID");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUPPLIER_NAME");
            });

            modelBuilder.Entity<Userlogin>(entity =>
            {
                entity.ToTable("USERLOGIN");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Customerid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMERID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Userlogins)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("FK_CUSTOMER1");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VENDORS");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.SupName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUP_NAME");

                entity.Property(e => e.SupplierId)
                    .HasPrecision(10)
                    .HasColumnName("SUPPLIER_ID");
            });

            modelBuilder.HasSequence("DEPARTMENT_ID");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
