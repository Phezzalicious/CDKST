using Microsoft.EntityFrameworkCore.Migrations;

namespace MyData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Composite",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    term_identifier = table.Column<string>(nullable: true),
                    prose_task_statement = table.Column<string>(nullable: true),
                    CompositeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Composite", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Composite_Composite_CompositeID",
                        column: x => x.CompositeID,
                        principalTable: "Composite",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DispositionApplied",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(nullable: true),
                    discipline = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispositionApplied", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DispositionDictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(nullable: true),
                    discipline = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispositionDictionary", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DispositionSynonym",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    text = table.Column<string>(nullable: true),
                    language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispositionSynonym", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeDictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(nullable: true),
                    discipline = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeDictionary", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SkillDictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(nullable: true),
                    discipline = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillDictionary", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Atomic",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    term_identifier = table.Column<string>(nullable: true),
                    prose_task_statement = table.Column<string>(nullable: true),
                    CompositeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atomic", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Atomic_Composite_CompositeID",
                        column: x => x.CompositeID,
                        principalTable: "Composite",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeElement",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    term_identifier = table.Column<string>(nullable: true),
                    cartesian_index = table.Column<int>(nullable: false),
                    semiotic_index = table.Column<int>(nullable: false),
                    descriptor = table.Column<string>(nullable: true),
                    etymology = table.Column<string>(nullable: true),
                    KnowledgeDictionaryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeElement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KnowledgeElement_KnowledgeDictionary_KnowledgeDictionaryID",
                        column: x => x.KnowledgeDictionaryID,
                        principalTable: "KnowledgeDictionary",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillLevel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    term_identifier = table.Column<string>(nullable: true),
                    cartesian_index = table.Column<int>(nullable: false),
                    descriptor = table.Column<string>(nullable: true),
                    SkillDictionaryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SkillLevel_SkillDictionary_SkillDictionaryID",
                        column: x => x.SkillDictionaryID,
                        principalTable: "SkillDictionary",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DispositionInstance",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    term_identifier = table.Column<string>(nullable: true),
                    cartesian_index = table.Column<int>(nullable: false),
                    descriptor = table.Column<string>(nullable: true),
                    appliedID = table.Column<int>(nullable: true),
                    synonymID = table.Column<int>(nullable: true),
                    AtomicID = table.Column<int>(nullable: true),
                    CompositeID = table.Column<int>(nullable: true),
                    DispositionDictionaryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispositionInstance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DispositionInstance_Atomic_AtomicID",
                        column: x => x.AtomicID,
                        principalTable: "Atomic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispositionInstance_Composite_CompositeID",
                        column: x => x.CompositeID,
                        principalTable: "Composite",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispositionInstance_DispositionDictionary_DispositionDictionaryID",
                        column: x => x.DispositionDictionaryID,
                        principalTable: "DispositionDictionary",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispositionInstance_DispositionApplied_appliedID",
                        column: x => x.appliedID,
                        principalTable: "DispositionApplied",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispositionInstance_DispositionSynonym_synonymID",
                        column: x => x.synonymID,
                        principalTable: "DispositionSynonym",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeSkill",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AtomicID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeSkill", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KnowledgeSkill_Atomic_AtomicID",
                        column: x => x.AtomicID,
                        principalTable: "Atomic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeSynonym",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    text = table.Column<string>(nullable: true),
                    language = table.Column<string>(nullable: true),
                    KnowledgeElementID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeSynonym", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KnowledgeSynonym_KnowledgeElement_KnowledgeElementID",
                        column: x => x.KnowledgeElementID,
                        principalTable: "KnowledgeElement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillVerbSynonym",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    text = table.Column<string>(nullable: true),
                    language = table.Column<string>(nullable: true),
                    SkillLevelID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillVerbSynonym", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SkillVerbSynonym_SkillLevel_SkillLevelID",
                        column: x => x.SkillLevelID,
                        principalTable: "SkillLevel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atomic_CompositeID",
                table: "Atomic",
                column: "CompositeID");

            migrationBuilder.CreateIndex(
                name: "IX_Composite_CompositeID",
                table: "Composite",
                column: "CompositeID");

            migrationBuilder.CreateIndex(
                name: "IX_DispositionInstance_AtomicID",
                table: "DispositionInstance",
                column: "AtomicID");

            migrationBuilder.CreateIndex(
                name: "IX_DispositionInstance_CompositeID",
                table: "DispositionInstance",
                column: "CompositeID");

            migrationBuilder.CreateIndex(
                name: "IX_DispositionInstance_DispositionDictionaryID",
                table: "DispositionInstance",
                column: "DispositionDictionaryID");

            migrationBuilder.CreateIndex(
                name: "IX_DispositionInstance_appliedID",
                table: "DispositionInstance",
                column: "appliedID");

            migrationBuilder.CreateIndex(
                name: "IX_DispositionInstance_synonymID",
                table: "DispositionInstance",
                column: "synonymID");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeElement_KnowledgeDictionaryID",
                table: "KnowledgeElement",
                column: "KnowledgeDictionaryID");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeSkill_AtomicID",
                table: "KnowledgeSkill",
                column: "AtomicID");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeSynonym_KnowledgeElementID",
                table: "KnowledgeSynonym",
                column: "KnowledgeElementID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillLevel_SkillDictionaryID",
                table: "SkillLevel",
                column: "SkillDictionaryID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillVerbSynonym_SkillLevelID",
                table: "SkillVerbSynonym",
                column: "SkillLevelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DispositionInstance");

            migrationBuilder.DropTable(
                name: "KnowledgeSkill");

            migrationBuilder.DropTable(
                name: "KnowledgeSynonym");

            migrationBuilder.DropTable(
                name: "SkillVerbSynonym");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "DispositionDictionary");

            migrationBuilder.DropTable(
                name: "DispositionApplied");

            migrationBuilder.DropTable(
                name: "DispositionSynonym");

            migrationBuilder.DropTable(
                name: "Atomic");

            migrationBuilder.DropTable(
                name: "KnowledgeElement");

            migrationBuilder.DropTable(
                name: "SkillLevel");

            migrationBuilder.DropTable(
                name: "Composite");

            migrationBuilder.DropTable(
                name: "KnowledgeDictionary");

            migrationBuilder.DropTable(
                name: "SkillDictionary");
        }
    }
}
