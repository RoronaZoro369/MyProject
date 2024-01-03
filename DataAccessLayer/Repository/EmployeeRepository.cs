using DataAccessLayer.DTO;
using DataAccessLayer.IRepository;
using DataAccessLayer.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(EmployeeDTO employee)
        {
            using (var connection = DbManager.GetOpenConnection())
            {
                using (var command = new SqlCommand(
                    "INSERT INTO Employee (Name, Email, Address, Contact) VALUES (@Name, @Email, @Address, @Contact)",
                    connection))
                {
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Contact", employee.Contact);

                    command.ExecuteNonQuery();
                }
            }
        }


        public void CreateEmployee(EmployeeDTO employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(
                    "INSERT INTO Employee (Name, Email, Address, Contact) VALUES (@Name, @Email, @Address, @Contact)",
                    connection))
                {
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Contact", employee.Contact);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateEmployees(EmployeesDTO employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(
                   @"INSERT INTO EmployeeDetails (EmployeeName, EmployeeID, Role, DateOfBirth, AadharNumber, NameAsAadhar, PANNumber, Gender, ReportingManager, 
                    Status, DateOfJoining, ProbationPeriod, ConfirmationDate, Email, MobileNumber, EmergencyContactName, EmergencyContactNumber, FatherName, SpouseName, 
                    Division, CostCenter, Grade, Designation, Location, Department, PaymentType, BloodGroup, MaritalStatus, Address, Street, Area, City, State, PinCode, 
                    Country, CurrentAddress, CurrentStreet, CurrentArea, CurrentCity, CurrentState, CurrentPinCode, CurrentCountry, EmergencyName, EmergencyMobileNumber, 
                    EmergencyRelationship, Qualification, FromYear, ToYear, InstituteName, Marks, Gap, Qualification1, FromYear1, ToYear1, InstituteName1, Marks1, Gap1, 
                    Qualification2, FromYear2, ToYear2, InstituteName2, Marks2, Gap2, CompanyName, Designations, EmploymentFromDate, EmploymentToDate, CompanyAddress, 
                    CompanyName1, Designation1, EmploymentFromDate1, EmploymentToDate1, CompanyAddress1, CompanyName2, Designation2, EmploymentFromDate2, EmploymentToDate2, 
                    CompanyAddress2, BankAccountNumber, BankIFSCCode, NameAsPerBankAccount, AccountType, PreviousPFAccountNumber, UAN, PassportNumber, NameAsPassport, ExpiryDate, 
                    FamilyMemberName, FamilyMemberRelationship, FamilyMemberDOB, FamilyMemberGender, FamilyMemberBloodGroup, FamilyMemberNationality, FamilyMemberName1, 
                    FamilyMemberRelationship1, FamilyMemberDOB1, FamilyMemberGender1, FamilyMemberBloodGroup1, FamilyMemberNationality1, FamilyMemberName2, 
                    FamilyMemberRelationship2, FamilyMemberDOB2, FamilyMemberGender2, FamilyMemberBloodGroup2, FamilyMemberNationality2, EPFNomineeName, EPFNomineePercent, 
                    EPFNomineeName1, EPFNomineePercent1, EPFNomineeName2, EPFNomineePercent2, EPSNomineeName, EPSNomineeName1, EPSNomineeName2, ESINomineeName, ESINomineeName1, 
                    ESINomineeName2, GratuityNomineeName, GratuityNomineePercentage, GratuityNomineeName1, GratuityNomineePercentage1, GratuityNomineeName2, 
                    GratuityNomineePercentage2, AddressAttachment, PresentAddressAttachment, PreviousEmploymentAttachment) " +
                   "VALUES " +
                   "(@EmployeeName, @EmployeeID, @Role, @DateOfBirth, @AadharNumber, @NameAsAadhar, @PANNumber, @Gender, @ReportingManager, @Status, @DateOfJoining, @ProbationPeriod, @ConfirmationDate, @Email, " +
                   "@MobileNumber, @EmergencyContactName, @EmergencyContactNumber, @FatherName, @SpouseName, @Division, @CostCenter, @Grade, @Designation, @Location, @Department, @PaymentType, @BloodGroup, " +
                   "@MaritalStatus, @Address, @Street, @Area, @City, @State, @PinCode, @Country, @CurrentAddress, @CurrentStreet, @CurrentArea, @CurrentCity, @CurrentState, @CurrentPinCode, @CurrentCountry, " +
                   "@EmergencyName, @EmergencyMobileNumber, @EmergencyRelationship, @Qualification, @FromYear, @ToYear, @InstituteName, @Marks, @Gap, @Qualification1, @FromYear1, @ToYear1, @InstituteName1, " +
                   "@Marks1, @Gap1, @Qualification2, @FromYear2, @ToYear2, @InstituteName2, @Marks2, @Gap2, @CompanyName, @Designations, @EmploymentFromDate, @EmploymentToDate, @CompanyAddress, @CompanyName1, " +
                   "@Designation1, @EmploymentFromDate1, @EmploymentToDate1, @CompanyAddress1, @CompanyName2, @Designation2, @EmploymentFromDate2, @EmploymentToDate2, @CompanyAddress2, @BankAccountNumber, " +
                   "@BankIFSCCode, @NameAsPerBankAccount, @AccountType, @PreviousPFAccountNumber, @UAN, @PassportNumber, @NameAsPassport, @ExpiryDate, @FamilyMemberName, @FamilyMemberRelationship, " +
                   "@FamilyMemberDOB, @FamilyMemberGender, @FamilyMemberBloodGroup, @FamilyMemberNationality, @FamilyMemberName1, @FamilyMemberRelationship1, @FamilyMemberDOB1, @FamilyMemberGender1, " +
                   "@FamilyMemberBloodGroup1, @FamilyMemberNationality1, @FamilyMemberName2, @FamilyMemberRelationship2, @FamilyMemberDOB2, @FamilyMemberGender2, @FamilyMemberBloodGroup2, " +
                   "@FamilyMemberNationality2, @EPFNomineeName, @EPFNomineePercent, @EPFNomineeName1, @EPFNomineePercent1, @EPFNomineeName2, @EPFNomineePercent2, @EPSNomineeName, @EPSNomineeName1, " +
                   "@EPSNomineeName2, @ESINomineeName, @ESINomineeName1, @ESINomineeName2, @GratuityNomineeName, @GratuityNomineePercentage, @GratuityNomineeName1, @GratuityNomineePercentage1, " +
                   "@GratuityNomineeName2, @GratuityNomineePercentage2, @AddressAttachment, @PresentAddressAttachment, @PreviousEmploymentAttachment)",
                   connection))
                {
                    command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                    command.Parameters.AddWithValue("@Role", employee.Role);
                    command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                    command.Parameters.AddWithValue("@AadharNumber", employee.AadharNumber);
                    command.Parameters.AddWithValue("@NameAsAadhar", employee.NameAsAadhar);
                    command.Parameters.AddWithValue("@PANNumber", employee.PANNumber);
                    command.Parameters.AddWithValue("@NameAsPAN", employee.NameAsPAN);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@ReportingManager", employee.ReportingManager);
                    command.Parameters.AddWithValue("@Status", employee.Status);
                    command.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);
                    command.Parameters.AddWithValue("@ProbationPeriod", employee.ProbationPeriod);
                    command.Parameters.AddWithValue("@ConfirmationDate", employee.ConfirmationDate);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@MobileNumber", employee.MobileNumber);
                    command.Parameters.AddWithValue("@EmergencyContactName", employee.EmergencyContactName);
                    command.Parameters.AddWithValue("@EmergencyContactNumber", employee.EmergencyContactNumber);
                    command.Parameters.AddWithValue("@FatherName", employee.FatherName);
                    command.Parameters.AddWithValue("@SpouseName", employee.SpouseName);
                    command.Parameters.AddWithValue("@Division", employee.Division);
                    command.Parameters.AddWithValue("@CostCenter", employee.CostCenter);
                    command.Parameters.AddWithValue("@Grade", employee.Grade);
                    command.Parameters.AddWithValue("@Designation", employee.Designation);
                    command.Parameters.AddWithValue("@Location", employee.Location);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@PaymentType", employee.PaymentType);
                    command.Parameters.AddWithValue("@BloodGroup", employee.BloodGroup);
                    command.Parameters.AddWithValue("@MaritalStatus", employee.MaritalStatus);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Street", employee.Street);
                    command.Parameters.AddWithValue("@Area", employee.Area);
                    command.Parameters.AddWithValue("@City", employee.City);
                    command.Parameters.AddWithValue("@State", employee.State);
                    command.Parameters.AddWithValue("@PinCode", employee.PinCode);
                    command.Parameters.AddWithValue("@Country", employee.Country);
                    command.Parameters.AddWithValue("@CurrentAddress", employee.CurrentAddress);
                    command.Parameters.AddWithValue("@CurrentStreet", employee.CurrentStreet);
                    command.Parameters.AddWithValue("@CurrentArea", employee.CurrentArea);
                    command.Parameters.AddWithValue("@CurrentCity", employee.CurrentCity);
                    command.Parameters.AddWithValue("@CurrentState", employee.CurrentState);
                    command.Parameters.AddWithValue("@CurrentPinCode", employee.CurrentPinCode);
                    command.Parameters.AddWithValue("@CurrentCountry", employee.CurrentCountry);
                    command.Parameters.AddWithValue("@EmergencyName", employee.EmergencyName);
                    command.Parameters.AddWithValue("@EmergencyMobileNumber", employee.EmergencyMobileNumber);
                    command.Parameters.AddWithValue("@EmergencyRelationship", employee.EmergencyRelationship);
                    command.Parameters.AddWithValue("@Qualification", employee.Qualification);
                    command.Parameters.AddWithValue("@FromYear", employee.FromYear);
                    command.Parameters.AddWithValue("@ToYear", employee.ToYear);
                    command.Parameters.AddWithValue("@InstituteName", employee.InstituteName);
                    command.Parameters.AddWithValue("@Marks", employee.Marks);
                    command.Parameters.AddWithValue("@Gap", employee.Gap);
                    command.Parameters.AddWithValue("@Qualification1", employee.Qualification1);
                    command.Parameters.AddWithValue("@FromYear1", employee.FromYear1);
                    command.Parameters.AddWithValue("@ToYear1", employee.ToYear1);
                    command.Parameters.AddWithValue("@InstituteName1", employee.InstituteName1);
                    command.Parameters.AddWithValue("@Marks1", employee.Marks1);
                    command.Parameters.AddWithValue("@Gap1", employee.Gap1);
                    command.Parameters.AddWithValue("@Qualification2", employee.Qualification2);
                    command.Parameters.AddWithValue("@FromYear2", employee.FromYear2);
                    command.Parameters.AddWithValue("@ToYear2", employee.ToYear2);
                    command.Parameters.AddWithValue("@InstituteName2", employee.InstituteName2);
                    command.Parameters.AddWithValue("@Marks2", employee.Marks2);
                    command.Parameters.AddWithValue("@Gap2", employee.Gap2);
                    command.Parameters.AddWithValue("@CompanyName", employee.CompanyName);
                    command.Parameters.AddWithValue("@Designations", employee.Designations);
                    command.Parameters.AddWithValue("@EmploymentFromDate", employee.EmploymentFromDate);
                    command.Parameters.AddWithValue("@EmploymentToDate", employee.EmploymentToDate);
                    command.Parameters.AddWithValue("@CompanyAddress", employee.CompanyAddress);
                    command.Parameters.AddWithValue("@CompanyName1", employee.CompanyName1);
                    command.Parameters.AddWithValue("@Designation1", employee.Designation1);
                    command.Parameters.AddWithValue("@EmploymentFromDate1", employee.EmploymentFromDate1);
                    command.Parameters.AddWithValue("@EmploymentToDate1", employee.EmploymentToDate1);
                    command.Parameters.AddWithValue("@CompanyAddress1", employee.CompanyAddress1);
                    command.Parameters.AddWithValue("@CompanyName2", employee.CompanyName2);
                    command.Parameters.AddWithValue("@Designation2", employee.Designation2);
                    command.Parameters.AddWithValue("@EmploymentFromDate2", employee.EmploymentFromDate2);
                    command.Parameters.AddWithValue("@EmploymentToDate2", employee.EmploymentToDate2);
                    command.Parameters.AddWithValue("@CompanyAddress2", employee.CompanyAddress2);
                    command.Parameters.AddWithValue("@BankAccountNumber", employee.BankAccountNumber);
                    command.Parameters.AddWithValue("@BankIFSCCode", employee.BankIFSCCode);
                    command.Parameters.AddWithValue("@NameAsPerBankAccount", employee.NameAsPerBankAccount);
                    command.Parameters.AddWithValue("@AccountType", employee.AccountType);
                    command.Parameters.AddWithValue("@PreviousPFAccountNumber", employee.PreviousPFAccountNumber);
                    command.Parameters.AddWithValue("@UAN", employee.UAN);
                    command.Parameters.AddWithValue("@PassportNumber", employee.PassportNumber);
                    command.Parameters.AddWithValue("@NameAsPassport", employee.NameAsPassport);
                    command.Parameters.AddWithValue("@ExpiryDate", employee.ExpiryDate);
                    command.Parameters.AddWithValue("@FamilyMemberName", employee.FamilyMemberName);
                    command.Parameters.AddWithValue("@FamilyMemberRelationship", employee.FamilyMemberRelationship);
                    command.Parameters.AddWithValue("@FamilyMemberDOB", employee.FamilyMemberDOB);
                    command.Parameters.AddWithValue("@FamilyMemberGender", employee.FamilyMemberGender);
                    command.Parameters.AddWithValue("@FamilyMemberBloodGroup", employee.FamilyMemberBloodGroup);
                    command.Parameters.AddWithValue("@FamilyMemberNationality", employee.FamilyMemberNationality);
                    command.Parameters.AddWithValue("@FamilyMemberName1", employee.FamilyMemberName1);
                    command.Parameters.AddWithValue("@FamilyMemberRelationship1", employee.FamilyMemberRelationship1);
                    command.Parameters.AddWithValue("@FamilyMemberDOB1", employee.FamilyMemberDOB1);
                    command.Parameters.AddWithValue("@FamilyMemberGender1", employee.FamilyMemberGender1);
                    command.Parameters.AddWithValue("@FamilyMemberBloodGroup1", employee.FamilyMemberBloodGroup1);
                    command.Parameters.AddWithValue("@FamilyMemberNationality1", employee.FamilyMemberNationality1);
                    command.Parameters.AddWithValue("@FamilyMemberName2", employee.FamilyMemberName2);
                    command.Parameters.AddWithValue("@FamilyMemberRelationship2", employee.FamilyMemberRelationship2);
                    command.Parameters.AddWithValue("@FamilyMemberDOB2", employee.FamilyMemberDOB2);
                    command.Parameters.AddWithValue("@FamilyMemberGender2", employee.FamilyMemberGender2);
                    command.Parameters.AddWithValue("@FamilyMemberBloodGroup2", employee.FamilyMemberBloodGroup2);
                    command.Parameters.AddWithValue("@FamilyMemberNationality2", employee.FamilyMemberNationality2);
                    command.Parameters.AddWithValue("@EPFNomineeName", employee.EPFNomineeName);
                    command.Parameters.AddWithValue("@EPFNomineePercent", employee.EPFNomineePercent);
                    command.Parameters.AddWithValue("@EPFNomineeName1", employee.EPFNomineeName1);
                    command.Parameters.AddWithValue("@EPFNomineePercent1", employee.EPFNomineePercent1);
                    command.Parameters.AddWithValue("@EPFNomineeName2", employee.EPFNomineeName2);
                    command.Parameters.AddWithValue("@EPFNomineePercent2", employee.EPFNomineePercent2);
                    command.Parameters.AddWithValue("@EPSNomineeName", employee.EPSNomineeName);
                    command.Parameters.AddWithValue("@EPSNomineeName1", employee.EPSNomineeName1);
                    command.Parameters.AddWithValue("@EPSNomineeName2", employee.EPSNomineeName2);
                    command.Parameters.AddWithValue("@ESINomineeName", employee.ESINomineeName);
                    command.Parameters.AddWithValue("@ESINomineeName1", employee.ESINomineeName1);
                    command.Parameters.AddWithValue("@ESINomineeName2", employee.ESINomineeName2);
                    command.Parameters.AddWithValue("@GratuityNomineeName", employee.GratuityNomineeName);
                    command.Parameters.AddWithValue("@GratuityNomineePercentage", employee.GratuityNomineePercentage);
                    command.Parameters.AddWithValue("@GratuityNomineeName1", employee.GratuityNomineeName1);
                    command.Parameters.AddWithValue("@GratuityNomineePercentage1", employee.GratuityNomineePercentage1);
                    command.Parameters.AddWithValue("@GratuityNomineeName2", employee.GratuityNomineeName2);
                    command.Parameters.AddWithValue("@GratuityNomineePercentage2", employee.GratuityNomineePercentage2);
                    command.Parameters.AddWithValue("@AddressAttachment", employee.AddressAttachment);
                    command.Parameters.AddWithValue("@PresentAddressAttachment", employee.PresentAddressAttachment);
                    command.Parameters.AddWithValue("@PreviousEmploymentAttachment", employee.PreviousEmploymentAttachment);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployeeById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("DELETE FROM Employee WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public EmployeeDTO FindById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand("SELECT * FROM Employee WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new EmployeeDTO
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    Contact = Convert.ToInt32(reader["Contact"])
                                };
                            }
                            else
                            {

                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var employees = new List<EmployeeDTO>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Employee";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new EmployeeDTO
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                Contact = Convert.ToInt32(reader["Contact"])
                            });
                        }
                    }
                }
            }

            return employees;
        }

        public void UpdateEmployee(EmployeeDTO employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(
                    "UPDATE Employee SET Name = @Name, Email = @Email, Address = @Address, Contact = @Contact WHERE Id = @Id",
                    connection))
                {
                    command.Parameters.AddWithValue("@Id", employee.Id);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Contact", employee.Contact);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
