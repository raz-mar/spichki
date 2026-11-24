namespace DefaultNamespace;

public class Expression
{
    private int _value;
    private ExprNodeType _type;
    private Expression _left;
    private Expression _right;
    enum ExprNodeType
    {
        PLUS,
        MINUS,
        EQUAL,
        NUMBER
    }

    private Expression(Expression left, Expression right, ExprNodeType type, int value = 0)
    {
        _left = left;
        _right = right;
        _type = type;
        _value = value;
    }

    public Expression(string exprString)
    {
        
    }

    public static Expression sum(int left, int right)
    {
        return new Expression(
            new Expression(null, null, ExprNodeType.NUMBER, left),
            new Expression(null, null, ExprNodeType.NUMBER, right),
            ExprNodeType.PLUS
        );
    }

    public static Expression sub(int left, int right)
    {
        return new Expression(
            new Expression(null, null, ExprNodeType.NUMBER, left),
            new Expression(null, null, ExprNodeType.NUMBER, right),
            ExprNodeType.MINUS
        );
    }

    public static Expression equ(int left, int right)
    {
        return new Expression(
            new Expression(null, null, ExprNodeType.NUMBER, left),
            new Expression(null, null, ExprNodeType.NUMBER, right),
            ExprNodeType.EQUAL
        );
    }
    
    int calculate()
    {
        return _type switch
        {
            ExprNodeType.NUMBER => _value,
            ExprNodeType.PLUS => _left.calculate() + _right.calculate(),
            ExprNodeType.MINUS => _left.calculate() - _right.calculate(),
            ExprNodeType.EQUAL => throw new InvalidOperationException("Уравнение проверяется через isValidEquation(), а не вычисляется"),
            _ => throw new InvalidOperationException($"Невозможно вычислить выражение типа {_type}")
        };
    }
    
    //TODO + isValidEquation() : boolean
    
    //TODO + isValidEquation() : boolean
    
    //TODO + toString() : string
}